using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace MarineFarm.Reportes.ReportePedidosActuales
{

    /// <summary>
    /// Para mostrar un resumen del los pedidos que actualmente se encuentran en proceso y que deben de ser entregados
    /// </summary>
    public static class ObtenerPedidosActuales
    {
        /// <summary>
        /// Para generar el listado de elementos que luego van en el reporte
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static async Task<List<PedidoDTO_out>> ListadoPedidos(ApplicationDbContext context, IMapper mapper)
        {
            List<PedidoDTO_out> list= new();
            try
            {
                var ent= await context.Pedidos
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Marisco)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.TipoProduccion)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Calibre)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Empaquetado)
                    .Include(ee => ee.Solicitante)
                    .Include(ee => ee.Cliente)
                    .Where(a=>a.act==true && a.estado==0)
                    .ToListAsync();

                if(ent!=null && ent.Count>0)
                {
                    list= mapper.Map<List<PedidoDTO_out>>(ent);
                    foreach (var pedido in list)
                       await pedido.Complete(context);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            
            return list;
        }

        /// <summary>
        /// Entrega un listado de los productos dentro del listado dado
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public static List<string> ListadoProductos(List<PedidoDTO_out> ins)
        {
            List<string> list=new();

           foreach (var pedido in ins)
               foreach(var prod in pedido.Productos)
               {
                    var text= $"{prod.Marisco} {prod.TipoProduccion} {prod.Calibre} {prod.Empaquetado}";
                    if(!list.Contains(text))   
                        list.Add(text);
               }
            
            return list;
        }

        /// <summary>
        /// Para Retornar un excel con los pedidos actuales
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public static async Task<byte[]> Excel(ApplicationDbContext context, IMapper mapper)
        {
            try{
                var list = await ListadoPedidos(context,mapper);

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

                        int row=3;

                        foreach (var item in list)
                        {
                            ew.Cells[row,1].Value= "Cliente";
                            ew.Cells[row,2].Value= item.Cliente;
                            ew.Cells[row,3].Value= "Fecha Posible Entrega";
                            ew.Cells[row,4].Value= item.FechaEntregaPosible.ToString("dd/MM/yyyy");
                            row++;

                            ew.Cells[row,1].Value= "Solicitante";
                            ew.Cells[row,2].Value= item.Solicitante;
                            ew.Cells[row,3].Value= "Fecha Genero Solicitud";
                            ew.Cells[row,4].Value= item.FechaSolicitud.ToString("dd/MM/yyyy");
                            row++;

                            ew.Cells[row,1].Value="Marisco";
                            ew.Cells[row,2].Value="Tipo De Produccion";
                            ew.Cells[row,3].Value="Calibre";
                            ew.Cells[row,4].Value="Empaquetado";
                            ew.Cells[row,5].Value="Cantidad Solicitado";
                            row++;
                            foreach (var prod in item.Productos)
                            {
                                ew.Cells[row,1].Value=prod.Marisco;
                                ew.Cells[row,2].Value=prod.TipoProduccion;
                                ew.Cells[row,3].Value=prod.Calibre;
                                ew.Cells[row,4].Value=prod.Empaquetado;
                                ew.Cells[row,5].Value=prod.Cantidad;
                                row++;
                            }
                            row+=2;
                        }


                        ep.SaveAs(ms);
                        return ms.ToArray();
                    }
                }
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return new byte[0];

        }
    }
    
}