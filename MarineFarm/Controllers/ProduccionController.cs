﻿using AutoMapper;
using MarineFarm.Auth;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
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
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ProduccionController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
                ViewBag.Mariscos = await context.Mariscos.Where(y => y.act == true).ToListAsync();
                ViewBag.Tps = await context.TiposProduccion.Where(y => y.act == true).ToListAsync();
                ViewBag.Calibres = await context.Calibres.Where(y => y.act == true).ToListAsync();
                ViewBag.Empaquetados = await context.Empaquetados.Where(y => y.act == true).ToListAsync();
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
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPost]
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
            return View(mapper.Map<List<ProduccionDTO_out>>(ent));
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
                var hoy = DateTime.Now;
                var ent = await context.Produccion
                    .Include(y => y.Superv)
                    .Where(y => y.Fecha>= periodo.Inicio.AddDays(-1)
                    && y.Fecha <= periodo.Fin.AddDays(1))
                    .ToListAsync();
                return View(mapper.Map<List<ProduccionDTO_out>>(ent));
            }

            return View();
        }


        #endregion



    }
}