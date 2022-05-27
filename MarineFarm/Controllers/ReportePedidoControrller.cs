
using AutoMapper;
using MarineFarm.Data;
using MarineFarm.Reportes.ReportePedidosActuales;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// Para obtener el reporte de los pedidos que estan actualmente en espera
    /// </summary>
    public class ReportePedidoController : Controller
    {
        /// <summary>
        /// contexto de datos
        /// </summary>
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Mapper. para mapeor diversos elementos
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ReportePedidoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        /// <summary>
        /// Vista Para ver el reporte actual
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
               return View(await ObtenerPedidosActuales.ListadoPedidos(context,mapper));
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return View();
        }
        /// <summary>
        /// PAra generar el excel de este reporte 
        /// </summary>
        /// <returns></returns>
        public async Task<FileResult> Excel()
        {
            try{
                var buffer = await ObtenerPedidosActuales.Excel(context,mapper);
                return File(buffer, "application/vnd.ms-excel", "Reporte De Pedidos Activos" + "- Generado el: " + DateTime.Now.ToString("dd/MM/yyyy") + ".xlsx");
            }catch(Exception ee){
                Console.WriteLine(ee.Message);
                return File(new byte[0], "application/vnd.ms-excel", "Error.xlsx");
            }
            
        }
    }
}