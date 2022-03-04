using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// Cargo Controller
    /// </summary>
    public class CargoController : Controller
    {
        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CargoController(ApplicationDbContext context, IMapper mapper )
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region vista inicial
        /// <summary>
        /// para la vista
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<CargosDTO_out> list = new();

            try
            {
                var ents = await context.Cargos.Where(x => x.act).ToListAsync();
                if (ents != null)
                    list = mapper.Map<List<CargosDTO_out>>(ents);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return View(list);
        }

        #endregion
    }
}
