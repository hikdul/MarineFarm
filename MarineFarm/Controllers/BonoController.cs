
using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// Para controlar la crud Visual de los bonos.  
    /// </summary>
    public class BonoController: Controller
    {
        #region ctor
        /// <summary>
        /// contexto de datos
        /// </summary>
        private readonly ApplicationDbContext context;
        /// <summary>
        /// Para generar los mapeos que necesite la clase
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public BonoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region Listado inicial   
        /// <summary>
        /// Vista Inicia para ver el listado de Bonos activos
        /// </summar
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                var ents = await context.Bonos
                   .Where(y=>y.act==true)
                   .ToListAsync();

                var list = mapper.Map<List<BonoDTO_out>>(ents);
                return View(list);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return View();
        }

        #endregion

        #region  crear Nuevo
        /// <summary>
        /// Vista para crear una nueva region
        /// </summary>
        /// <returns></returns>
        public IActionResult Nuevo()
        {
            return View();
        }


    /// <summary>
    ///  Para Almacenar los datos
    /// </summary>
    /// <param name="ins"></param>
    /// <returns></returns>
        public async Task<IActionResult> Crear(BonoDTO_in ins)
        {
            try
            {
                var ent = mapper.Map<Bono>(ins);
                context.Add(ent);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                ViewBag.Err="Datos No Validos Para Crear Un Nuevo Bono";
                return View("Nuevo",ins);
            }
        }
        #endregion

        #region  Editar
        /// <summary>
        /// Vista para ver los datos actuales y generar las ediciones
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                var ent=await context.Bonos
                .FirstOrDefaultAsync(y=>y.id==id);   
                var dto= mapper.Map<BonoDTO_Edit>(ent);
                dto.id = id;
                return View(dto);

            }
            catch (Exception ee)
            {
              Console.WriteLine(ee.Message);   
            }

            return View();
        }

        /// <summary>
        ///  para guardor los nuevos datos del bono
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(BonoDTO_Edit ins)
        {
            try
            {
                var original=await context.Bonos.FirstOrDefaultAsync(y=>y.id==ins.id);
                original = mapper.Map(ins, original);
                await context.SaveChangesAsync();

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region  Delete

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Eliminar(int id)
        {
                try
                {
                    var ent= await context.Bonos.FirstOrDefaultAsync(y=>y.id==id);
                    ent.act =false;
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