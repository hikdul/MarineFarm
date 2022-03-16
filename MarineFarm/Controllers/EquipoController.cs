using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para manipular los equipos por turnos
    /// </summary>

    [Authorize]
    public class EquipoController : Controller
    {
        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public EquipoController(ApplicationDbContext context, IMapper mapper)
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
            List<EquipoDTO_out> list = new();

            try
            {
                var turno = await context.Turnos.Where(x => x.act == true).ToListAsync();

                if (turno != null && turno.Count > 0)
                {
                    var ent = await context.Equipos
                        .Include(x => x.Cargo)
                        .ToListAsync();

                    list = EquipoDTO_out.Up(ent, turno);
                }
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
        public async Task<IActionResult> Crear()
        {
            List<__inV> cargosVista = new();
            try
            {
                var cargos = await context.Cargos.Where(x => x.act == true).ToListAsync();
                foreach (var item in cargos)
                {
                    cargosVista.Add(new()
                    {
                        CantCubierta = 0,
                        Cargoid = item.id,
                        CargoName = item.Name,
                        CostoOperario = 0
                    });
                }
                ViewBag.Cargos = cargosVista;   

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return View();
        }

        /// <summary>
        /// Para almacenar que los nuevos datos
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Guardar(CargosDTO_in ins)
        {
           
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
          

            return View();
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
