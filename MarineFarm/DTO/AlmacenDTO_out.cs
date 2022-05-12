using AutoMapper;
using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace MarineFarm.DTO
{
    public class AlmacenDTO_out
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Cantidad en almacen
        /// </summary>
        public double Cantidad { get; set; } = 0;
        /// <summary>
        /// Marisco
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Tipo de produccion
        /// </summary>
        public string TipoProduccion { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        public string Calibre { get; set; }
        /// <summary>
        /// Empaquetado
        /// </summary>
        public string Empaquetado { get; set; }
        #endregion

        #region listado actual
        /// <summary>
        ///  Para obtener el listado de elementos actuales y positivos en el almacen
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static async Task<List<AlmacenDTO_out>> Listar(ApplicationDbContext context, IMapper mapper)
        {
            try
            {
                
                var ents = await context.Almacen
                     .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                     .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                     .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                     .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                     .Where(x => x.Cantidad > 0)
                     .ToListAsync();

                return mapper.Map<List<AlmacenDTO_out>>(ents);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return new();
            }
        }
        #endregion

        #region  Excel
        /// <summary>
        /// Para generar un excel con los datos que se entregen
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static byte[] Excel(List<AlmacenDTO_out> list)
        {
            try
            {
                
                using (MemoryStream ms = new MemoryStream())
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage ep = new ExcelPackage())
                    {
                        ep.Workbook.Worksheets.Add("Reporte Poduccion Entre Periodos");
                        ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                        ew.Cells.Style.Font.Size = 10;
                        ew.Cells.Style.Font.Name = "Arial";

                        ew.Cells[1, 1].Value = "Reporte Generado ";
                        ew.Cells[1, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        ew.Cells[3,1].Value = "Marisco";
                        ew.Cells[3,2].Value = "Tipo Produccion";
                        ew.Cells[3,3].Value = "Calibre";
                        ew.Cells[3,4].Value = "Empaquetado";
                        ew.Cells[3,5].Value = "Cantida Almacenada";
                        int fila=4;
                        foreach (var a in list)
                        {
                            
                            ew.Cells[fila,1].Value = a.Marisco;
                            ew.Cells[fila,2].Value = a.TipoProduccion;
                            ew.Cells[fila,3].Value = a.Calibre;
                            ew.Cells[fila,4].Value = a.Empaquetado;
                            ew.Cells[fila,5].Value = a.Cantidad;
                            fila++;
                        }
                         
                        ep.SaveAs(ms);
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return new byte[0];
            }
        }

        #endregion
    }
}
