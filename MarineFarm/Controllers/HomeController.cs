using MarineFarm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// pagina inicial del sistema
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
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