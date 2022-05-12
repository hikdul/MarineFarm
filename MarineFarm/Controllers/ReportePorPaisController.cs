
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
using MarineFarm.Reportes.ReporteXPais;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para llevar los eventos de la produccion
    /// </summary>
    public class ReportePorPaisController : Controller
    {

        #region ctor
        /// <summary>
        /// contexto de datos
        /// </summary>
        private readonly ApplicationDbContext context;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public ReportePorPaisController(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion

        /// <summary>
        /// Vista para ver las opciones para genera el reporte
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index() 
        {
                try
                {
                    ViewBag.fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    ViewBag.Marisco = await  ToSelect.ToSelectITipoStringEnter<Marisco>(context,"0");
                    ViewBag.Calibre = await ToSelect.ToSelectITipoStringEnter<Calibre>(context,"0");
                    ViewBag.Paises = await Paises.ObtenerPaises();

                }
                catch (Exception ee)
                {
                   Console.WriteLine(ee.Message);
                }
            return View();
        } 
        /// <summary>
        /// Para generary mostar en su vista el reporte
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Generar(RepotePorPaisDTO_in ins)
        {
            
            try
            {
                var model = new ReportePorPais();
                await model.Up(ins,context);
                ViewBag.reporte = model;
                ViewBag.fi = ins.Inicio;
                ViewBag.ff = ins.Fin;
                ViewBag.pais = ins.Pais;
                ViewBag.Mariscoid = ins.Mariscoid;
                ViewBag.Calibreid = ins.Calibreid;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return View();
        }

        /// <summary>
        /// Para generar el excel del reporte actual
        /// </summary>
        /// <param name="ins"></param>
        public async Task<FileResult> Excel(RepotePorPaisDTO_in ins)
        {

            try
            {
                if (ins == null )
                    return File(new byte[0], "application/vnd.ms-excel", "AlMenosSeleccioneUnEmpleado.xlsx");

                ReportePorPais reporte = new();
                await reporte.Up(ins, context);
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

    }
}