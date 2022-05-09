using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// este controlador es para manipular ciertos datos de la configuracion 
    /// </summary>
    public class configurationController : Controller
    {
        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public configurationController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion



        #region vista de la configuracion actual
        /// <summary>
        /// pagina principal
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            ConfigurcionDTO dto = new();
            try
            {
                var ent = await context.Config
                .FirstOrDefaultAsync();

                if(ent==null || ent.id <1)
                {
                    ent = new()
                    {
                        ProduccionDefaultPorDia = 5000,
                        DiasHabiles = 5,
                        
                    };
                    context.Add(ent);
                    await context.SaveChangesAsync();
                }

                dto = mapper.Map<ConfigurcionDTO>(ent);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            return View(dto);
        }

        #endregion


        #region editar
        /// <summary>
        /// para editar los datos de la configuracion
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Editar(ConfigurcionDTO ins)
        {
            try
            {
                var ent = await context.Config.Where(y => y.id == ins.id).FirstOrDefaultAsync();
                ent = mapper.Map(ins, ent);

                await context.SaveChangesAsync();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return RedirectToAction("Index");
        }

        #endregion


    }
}
