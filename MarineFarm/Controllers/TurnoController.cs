using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// Turno Controller
    /// </summary>
    public class TurnoController : Controller
    {
        #region ctor

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public TurnoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion

        #region vista inicial

        /// <summary>
        /// Vista del listado de mariscos activos
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<GTipoDTO_out> ret = new();
            try
            {
                var ents = await context
                    .Turnos
                    .Where(x => x.act == true)
                    .ToListAsync();

                ret = mapper.Map<List<GTipoDTO_out>>(ents);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return View(ret);
        }

        #endregion

        #region Crear

        /// <summary>
        /// Crear Nuevo Elemento
        /// </summary>
        /// <returns></returns>
        public IActionResult Crear()
        {
            return View();
        }

        /// <summary>
        /// Para almacenar que los nuevos datos
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Guardar(GTipoDTO_in ins)
        {
            try
            {
                var ent = mapper.Map<Turnos>(ins);
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

        #region Editar

        /// <summary>
        /// vista para editar un elemento en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Editar(int id)
        {
            GTipoDTO_edit dto = new();
            try
            {
                var ent = await context
                    .Turnos
                    .Where(x => x.id == id)
                    .FirstOrDefaultAsync();

                dto = mapper.Map<GTipoDTO_edit>(ent);

            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return View(dto);
        }
        /// <summary>
        /// Para almacenar los datos de un nuevo elemento
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(GTipoDTO_edit ins)
        {
            try
            {
                var ent = await context.Turnos
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
                var ent = await context.Turnos
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
