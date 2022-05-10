using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
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
                        CostoOperario = 0,
                        CantOperadoresNecesario = item.CantOperadoresNecesario
                    });
                }
                ViewBag.Cargos = cargosVista;   
                ViewBag.Bonos= await ToSelect.ToSelectITipo<Bono>(context,1);
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
        public async Task<IActionResult> Guardar(EquipoDTO_in ins)
        {

            try
            {

                var entT = mapper.Map<Turnos>(ins.turno);

                context.Add(entT);

                await context.SaveChangesAsync();

                foreach (var item in ins.cargos)
                {
                    var ent = new Equipo()
                    {
                        CantCubierta = item.CantCubierta,
                        Cargoid = item.Cargoid,
                        CostoOperario = item.CostoOperario,
                        Turnoid = entT.id,
                        Bonoid= item.Bonoid 
                    };

                    context.Add(ent);
                }
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                ViewBag.Err = "Upps, algo salio mal. Verifique los datos ingresados";
                return View("Crear", ins);
            }
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
            ViewBag.id = id;
            List<__inV> cargosVista = new(); 
            try
            {
                //datos dinamicos alterables
                var turno = await context.Turnos.Where(y => y.id == id).FirstOrDefaultAsync();
                var equipo = await context.Equipos
                    .Include(y=>y.Cargo)
                    .Where(y => y.Turnoid == id)
                    .ToListAsync();
                //datos dinamicos fijos
                var cargos = await context.Cargos
                    .Where(x => x.act == true)
                    .ToListAsync();
                
                foreach (var item in cargos)
                {
                    var eq = equipo.Where(x => x.Cargoid == item.id).FirstOrDefault();

                    int cantCubierta = eq==null? 0: eq.CantCubierta;
                    double costo =eq==null? 0:eq.CostoOperario;
                    cargosVista.Add(new()
                    {
                        CantCubierta = cantCubierta,
                        Cargoid = item.id,
                        CargoName = item.Name,
                        CostoOperario = costo,
                        CantOperadoresNecesario = item.CantOperadoresNecesario,
                    });
                }

                ViewBag.Bonos= await ToSelect.ToSelectITipo<Bono>(context,1);
                ViewBag.Cargos = cargosVista;
                ViewBag.turno = turno;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }


            return View();
        }

        /// <summary>
        /// para guardar los nuevos datos editados
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<bool> Edit(EquipoDTO_Edit ins) 
        {

            int id = ins.turno.id;


            try
            {
                var turno = await context.Turnos.Where(y => y.id == id).FirstOrDefaultAsync();
                //guiarda y editar los cambmios enel turno.
                turno.act = true;
                turno.Name = ins.turno.Name;
                turno.Desc = ins.turno.Desc;
                await context.SaveChangesAsync();

                //guardar los cambios que sean para el equipo en general

                var equipos = await context.Equipos
                    .Where(y => y.Turnoid == id)
                    .ToListAsync();

                foreach (var item in equipos)
                {
                    var cambio = ins.cargos.Where(y => y.Cargoid == item.Cargoid).FirstOrDefault();
                    if (item != null && cambio!=null)
                    {
                        item.CantCubierta = cambio.CantCubierta;
                        item.CostoOperario = cambio.CostoOperario;
                        item.Bonoid = cambio.Bonoid;
                        await context.SaveChangesAsync();
                    }
                    
                }

                return true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return false;
            }
            
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
