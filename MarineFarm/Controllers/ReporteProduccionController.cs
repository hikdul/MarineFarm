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
    public class ReporteProduccionController : Controller
    {
        #region ctor

        private readonly ApplicationDbContext context;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public ReporteProduccionController(ApplicationDbContext context)
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
                ViewBag.Mariscos = await ToSelect.ToSelectITipo<Marisco>(context,-5);
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
                if(!ins.validate())
                {
                    ViewBag.Err = "Datos Ingresados no validos";
                    return View("Index", ins);
                }

                await reporte.Generate(ins, context);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return View("Index", ins);
            }
            ViewBag.Reporte = reporte;
            return View();
        }
        #endregion

        #region excel
        /// <summary>
        /// para exportar el reporte en un excel
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<FileResult> Excel(AllReportDTO_in ins)
        {
            return null;
        }

        #endregion

    }
}
