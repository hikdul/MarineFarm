using MarineFarm.Data;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
using MarineFarm.Reportes.TotalProduccion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
            ViewBag.fi = ins.Inicio;
            ViewBag.ff = ins.Fin;
            List<SelectListItem> listAux = new();

            foreach (var id in ins.Mariscoid)
            {
                listAux.Add(new(id.ToString(), id.ToString(), true));
            }

            ViewBag.ids = listAux;
            
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
        public async System.Threading.Tasks.Task<FileResult> Excel(AllReportDTO_in ins)
        {
            try
            {
                if (ins == null )
                    return File(new byte[0], "application/vnd.ms-excel", "AlMenosSeleccioneUnEmpleado.xlsx");

                ReporteTotalProduccion reporte = new();
                await reporte.Generate(ins, context);
                var buffer = reporte.Excel();
                return File(buffer, "application/vnd.ms-excel", "Reporte Produccion" + "-" + ins.Inicio.ToString("dd/MM/yyyy") + "-al-" + ins.Fin.ToString("dd/MM/yyyy") + ".xlsx");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Catch!!");
                Console.WriteLine("Exception msn: {0}", ex.Message);
                return File(new byte[0], "application/vnd.ms-excel", "Empty.xlsx");

            }
        }
        #endregion

    }
}
