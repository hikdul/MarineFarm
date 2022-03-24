using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para controlar los datos del almacen de productos finales
    /// </summary>
    public class AlmacenController : Controller
    {


        #region ctor

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public AlmacenController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion



        #region vista principal 

        /// <summary>
        /// vista de los datos actuales
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<AlmacenDTO_out> list = new();
            try
            {

                var ents = await context.Almacen
                     .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                     .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                     .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                     .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                     .Where(x => x.Cantidad > 0)
                     .ToListAsync();

                list = mapper.Map<List<AlmacenDTO_out>>(ents);


            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }


            return View(list);
        }


        #endregion


        

    }
}
