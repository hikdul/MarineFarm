using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// controlador para la pagina inicial!!
    /// </summary>

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }
        #region pagina principal
        /// <summary>
        /// pagina inicial del sistema
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// para obtener los datos de las muestras diarias del ano actual.
        /// estos datos son para imprimir las charts en pantalla
        /// </summary>
        /// <returns></returns>
        public async Task<PieDTO_out?> DatosPie()
        {
            try
            {
                var ent = await context.MuestrasDiarias
                    .Include(y=>y.Marisco)
                    .Include(y=>y.TipoProduccion)
                    .Include(y=>y.Calibre)
                    .Include(y=>y.Empaquetado)
                    .Where(y => y.ano == DateTime.Now.Year && y.mes == DateTime.Now.Month)
                    .ToListAsync();

                return new(ent);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return null;
            }
        }

        #endregion pagina secundaria
        /// <summary>
        /// politica de privacidad
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Error Page
        /// </summary>
        /// <returns></returns>

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}