using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// Cargo Controller
    /// </summary>
    [Authorize]
    public class CargoController : Controller
    {
        private readonly ApplicationDbContext context;
        #region ctor
        /// <summary>
        /// para el mapeo de datos
        /// </summary>
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


        #region crear

        /// <summary>
        /// vista para crear un nueva cargo
        /// </summary>
        /// <returns></returns>
        public IActionResult Crear()
        {
            ViewBag.Sx = Cargos.SexoToSelect();
            return View();
        }

        /// <summary>
        /// Para almacenar que los nuevos datos
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Guardar(CargosDTO_in ins)
        {
            try
            {
                var ent = mapper.Map<Cargos>(ins);
                context.Add(ent);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        #endregion


        #region editar



        /// <summary>
        /// vista para editar un elemento en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Editar(int id)
        {
            CargoDTO_edit dto = new();
            try
            {
                var ent = await context
                    .Cargos
                    .Where(x => x.id == id)
                    .FirstOrDefaultAsync();

                dto = mapper.Map<CargoDTO_edit>(ent);

            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }

            ViewBag.Sx = Cargos.SexoToSelect();

            return View(dto);
        }

        /// <summary>
        /// Para almacenar los datos de un nuevo elemento
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(CargoDTO_edit ins)
        {
            try
            {
                var ent = await context.Cargos
                    .Where(ee => ee.id == ins.id)
                    .FirstOrDefaultAsync();
                ent = mapper.Map(ins, ent);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Delete
        /// <summary>
        /// Para eliminar un elemento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var ent = await context.Cargos
                    .Where(e => e.id == id)
                    .FirstOrDefaultAsync();
                if (ent != null)
                {
                    ent.act = false;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return RedirectToAction("Index");
        }

        #endregion

    }
}
