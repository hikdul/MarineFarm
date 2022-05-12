using AutoMapper;
using MarineFarm.Data;
using MarineFarm.Entitys;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace MarineFarm.DTO
{
    /// <summary>
    /// datos del producto sin mucho detalle
    /// </summary>
    public class PedidoDTOS_out
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// si el elemento se encuentra activo o no
        /// </summary>
        public bool act { get; set; }
        /// <summary>
        /// Cliente al que pertenece el pedido
        /// </summary>
        public int Clienteid { get; set; }
        /// <summary>
        /// Nombre Cliente
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// Nombre Solicitante
        /// </summary>
        public string Solicitante { get; set; }
        /// <summary>
        /// fecha en que se genero la solicitud
        /// </summary>
        public DateTime FechaSolicitud { get; set; }
        /// <summary>
        /// fecha en que se realizo la entrega del producto
        /// </summary>
        public DateTime? FechaEntrega { get; set; }
        /// <summary>
        /// fecha en que el sistema cree se entregara el producto
        /// </summary>
        public DateTime FechaEntregaPosible { get; set; }
        /// <summary>
        /// estado del pedido
        /// 0 => solicitado
        /// 1 => completado
        /// 2 => cancelado
        /// </summary>
        public int estado { get; set; }
        /// <summary>
        /// descripcion del estado
        /// </summary>
        public string EstadoDesc { get; set; }=string.Empty;
        #endregion

        #region Generar Excel por medio de un listado
        /// <summary>
        ///  Para generar el excel enviando una lista de elemento
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static byte[] excel(List<PedidoDTOS_out> list)
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

                        ew.Cells[1, 1].Value = "Listado Exportado ";
                        ew.Cells[1, 2].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        ew.Cells[3, 1].Value = "Cliente";
                        ew.Cells[3, 2].Value = "Solicitante";
                        ew.Cells[3, 3].Value = "Fecha Solicitud";
                        ew.Cells[3, 4].Value = "Fecha de Posible entrega";
                        ew.Cells[3, 5].Value = "Estado Pedido";


                        int f = 5;
                        foreach (var element in list)
                        {
                            ew.Cells[f, 1].Value = element.Cliente;
                            ew.Cells[f, 2].Value = element.Solicitante;
                            ew.Cells[f, 3].Value = element.FechaSolicitud;
                            ew.Cells[f, 4].Value = element.FechaEntregaPosible;
                            ew.Cells[f, 5].Value = element.EstadoDesc;
                            f++;
                        }

                        ep.SaveAs(ms);
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return new byte[0];

        }

        #endregion


        #region  Generar listado en base a un cliente
        /// <summary>
        /// me genera la lista de elementos validos y filtrados segun el cliente
        /// </summary>
        /// <param name="context"></param>
        /// <param name="User"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static async Task<List<PedidoDTOS_out>> Listado(ApplicationDbContext context, System.Security.Claims.ClaimsPrincipal User, IMapper mapper )
        {
            try
            {
                    
                List<Pedido> ent = new();
                if (User.IsInRole("Cliente"))
                {
                    var client = await context.UsuarioClientes
                        .Include(x=>x.Usuario)
                        .Where(x => x.Usuario.Email == User.Identity.Name)
                        .FirstOrDefaultAsync();

                    ent = await context.Pedidos
                     .Include(ee => ee.Solicitante)
                    .Include(ee => ee.Cliente)
                    .Where(y => y.Clienteid== client.Clienteid  && y.act == true && y.estado == 0)
                    .ToListAsync();

                }
                else
                    ent = await context.Pedidos
                     .Include(ee => ee.Solicitante)
                    .Include(ee => ee.Cliente)
                    .Where(y => y.act == true && y.estado==0)
                    .ToListAsync();
                
                return mapper.Map<List<PedidoDTOS_out>>(ent);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return new();
        }
        #endregion

     
    }
}


