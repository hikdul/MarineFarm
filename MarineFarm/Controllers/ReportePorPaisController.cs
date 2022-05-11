
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
        public void Excel(RepotePorPaisDTO_in ins)
        {

            return; 
        }

    }
}