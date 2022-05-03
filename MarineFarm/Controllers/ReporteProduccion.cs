using MarineFarm.Data;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
using MarineFarm.Reportes.TotalProduccion;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para generar los reportes de produccion
    /// </summary>
    public class ReporteProduccion : Controller
    {
        #region ctor

        private readonly ApplicationDbContext context;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public ReporteProduccion(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion


        #region datos para generar el reporte
        /// <summary>
        /// vista para generar el reporte
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.Mariscos = await ToSelect.ToSelectITipo<Marisco>(context);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
                return View();
        }
        #endregion


        #region generar reporte
        /// <summary>
        /// vista donde el reporte se genero
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Generado(AllReportDTO_in ins)
        {
            ReporteTotalProduccion reporte = new();
            ViewBag.GenerarReporte = ins;
            try
            {

                await reporte.Generate(ins, context);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return View(reporte);
        }
        #endregion

    }
}
