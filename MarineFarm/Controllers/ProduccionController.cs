using AutoMapper;
using MarineFarm.Auth;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
using MarineFarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para llevar los eventos de la produccion
    /// </summary>
    public class ProduccionController : Controller
    {
        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ISaveMuestrasDiarias md;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="md"></param>
        public ProduccionController(ApplicationDbContext context, IMapper mapper, ISaveMuestrasDiarias md)
        {
            this.context = context;
            this.mapper = mapper;
            this.md = md;
        }

        #endregion

        #region Generar producccion

        /// <summary>
        /// vista para generar una nueva produccion
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.Mariscos = await ToSelect.ToSelectITipo<Marisco>(context); // await context.Mariscos.Where(y => y.act == true).ToListAsync();
                ViewBag.Tps = await ToSelect.ToSelectITipo<TipoProduccion>(context);// context.TiposProduccion.Where(y => y.act == true).ToListAsync();
                ViewBag.Calibres = await ToSelect.ToSelectITipo<Calibre>(context);// context.Calibres.Where(y => y.act == true).ToListAsync();
                ViewBag.Empaquetados = await ToSelect.ToSelectITipo<Empaquetado>(context);// context.Empaquetados.Where(y => y.act == true).ToListAsync();
                ViewBag.fecha = DateTime.Now.ToString("yyyy-MM-dd");
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return View();
        }



        /// <summary>
        /// para obtener los datos desde la vista
        /// </summary>
        /// <param name="insert"></param>
        /// <returns></returns>
        
        public async Task<IActionResult> SeeData(ProduccionDTOView_in insert)
        {

            ProduccionDTO_in ins = new(insert);

            try
            {
                //valida y en caso de no ser valido retorna la data
                var valid = await ins.inValid(context);

                if (valid == null || valid.Count == 0)
                {
                    var flagUs = await Usuario.GetByEmail(User.Identity.Name, context);

                    if (flagUs == null || flagUs.id < 1)
                        return BadRequest("Usuario no valida para ejecutar esta accion");

                    //generar entidad
                    var ent = await Produccion.Up(ins, flagUs.id, context);




                    //almacena los datos de produccion
                    context.Add(ent);
                    await context.SaveChangesAsync();

                    
                    //todo bien ahora tocamos materia prima 

                    foreach (var item in ent.MariscosProduccion)
                    {
                        MateriaPrimaDTO_in aux = new()
                        {
                            Cantidad = item.CantidadUtilizada,
                            Mariscoid = item.Mariscoid
                        };
                        var bb = await aux.Substract(context, mapper);
                    }
                    //y por ultimo tocamos el almacen

                    foreach (var item in ent.ProductoProduccion)
                    {
                        var aux = await AlmacenDTO_in.costructor(context, item.Productoid, item.CantidadProducida);
                        await aux.Add(context, mapper);
                    }

                    //para que corra la tarea en otra hilo y asi me almacene los datos.
                    _ = Task.Run(async () =>
                   {

                       int ano = DateTime.Now.Year;
                       int mes = DateTime.Now.Month;

                       foreach (var item in ent.ProductoProduccion)
                       {
                           MuestraDiaria muestra = new()
                           {
                               ano = ano,
                               mes = mes,
                               TotalProducido = item.CantidadProducida,
                               ProduccionDiaria = item.CantidadProducida,
                               Calibreid = item.Producto.TipoProduccionid,
                               TipoProduccionid = item.Producto.Calibreid,
                               Empaquetadoid = item.Producto.Empaquetadoid,
                               Mariscoid = item.Producto.Mariscoid,
                           };
                           await md.Save(muestra);
                       }
                   });


                    // da respuesta con el resultado obtenido pero mapeado a otro elemento
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["errores"] = valid;
                    return View("Index", ins);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return View("Index", ins);

            }


        }


        /// <summary>
        /// para almacenar los datos de la produccion generada
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        private async Task<IActionResult> Guardar(ProduccionDTO_in ins)
        {
          
            try
            {

                //valida y en caso de no ser valido retorna la data
                var valid = await ins.inValid(context);

                if (valid == null || valid.Count == 0)
                {
                    var flagUs = await Usuario.GetByEmail(User.Identity.Name, context);

                    if (flagUs == null || flagUs.id < 1)
                        return BadRequest("Usuario no valida para ejecutar esta accion");

                    //generar entidad
                    var ent = await Produccion.Up(ins, flagUs.id, context);


                    //almacena los datos de produccion
                    context.Add(ent);
                    await context.SaveChangesAsync();

                    //todo bien ahora tocamos materia prima 

                    foreach (var item in ent.MariscosProduccion)
                    {
                        MateriaPrimaDTO_in aux = new()
                        {
                            Cantidad = item.CantidadUtilizada,
                            Mariscoid = item.Mariscoid
                        };
                        var bb = await aux.Substract(context, mapper);
                    }
                    //y por ultimo tocamos el almacen

                    foreach (var item in ent.ProductoProduccion)
                    {
                        var aux = await AlmacenDTO_in.costructor(context, item.Productoid, item.CantidadProducida);
                        await aux.Add(context, mapper);
                    }

                    // da respuesta con el resultado obtenido pero mapeado a otro elemento
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["errores"] = valid;
                    return View("Index", ins);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return View("Index", ins);

            }


        }


        #endregion

        #region historial


        /// <summary>
        /// para ver el historial de pedidos
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Historial()
        {
            var hoy = DateTime.Now;
            var ent = await context.Produccion
                .Include(y => y.Superv)
                .Where(y => y.Fecha.Day == hoy.Day 
                        && y.Fecha.Month == hoy.Month 
                        && y.Fecha.Year == hoy.Year)
                .ToListAsync();
            ViewBag.history = mapper.Map<List<ProduccionDTO_out>>(ent);
            return View();
        }
        /// <summary>
        /// para buscar elementos pasandole un periodo
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public async Task<IActionResult> HistorialF(Periodo periodo)
        {
            if (periodo.Validate())
            {
                ViewBag.inicio=periodo.Inicio.ToString("yyyy-MM-dd");
                ViewBag.fin=periodo.Fin.ToString("yyyy-MM-dd");
                var ent = await context.Produccion
                    .Include(y => y.Superv)
                    .Where(y => y.Fecha>= periodo.Inicio.AddDays(-1)
                    && y.Fecha <= periodo.Fin.AddDays(1))
                    .ToListAsync();
                ViewBag.history = mapper.Map<List<ProduccionDTO_out>>(ent);
                return View(periodo);
            }

            return View();
        }


        #endregion

        #region detalles de una produccion

        /// <summary>
        /// detalle de una produccion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var ent = await context.Produccion.Where(x => x.Fecha.Year > 2000)
                 .Include(x => x.Superv)
                 .Include(x => x.MariscosProduccion).ThenInclude(x => x.Marisco)
                 .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Marisco)
                 .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.TipoProduccion)
                 .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Calibre)
                 .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Empaquetado)
                 .Where(x => x.id == id)
                 .FirstOrDefaultAsync();

                var dto = mapper.Map<ProduccionDTO_out>(ent);
                return View(dto);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return View();
            }
        }

        

        #endregion


    }
}
