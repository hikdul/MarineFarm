﻿using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para manipular la data del pedido
    /// </summary>
    public class PedidoController : Controller
    {
        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public PedidoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion


        #region Generar Pedido
        /// <summary>
        /// vista para generar los pedidos
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Generar()
        {
            try
            {
                ViewBag.Mariscos = await ToSelect.ToSelectITipo<Marisco>(context); // await context.Mariscos.Where(y => y.act == true).ToListAsync();
                ViewBag.Tps = await ToSelect.ToSelectITipo<TipoProduccion>(context);// context.TiposProduccion.Where(y => y.act == true).ToListAsync();
                ViewBag.Calibres = await ToSelect.ToSelectITipo<Calibre>(context);// context.Calibres.Where(y => y.act == true).ToListAsync();
                ViewBag.Empaquetados = await ToSelect.ToSelectITipo<Empaquetado>(context);// context.Empaquetados.Where(y => y.act == true).ToListAsync();
                ViewBag.Clientes = await ToSelect.ToSelectITipo<Cliente>(context);
                ViewBag.fecha = DateTime.Now.ToString("yyyy-MM-dd");
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return View();
        }
        /// <summary>
        /// Para Calcular un pedido
        /// </summary>
        /// <returns></returns>
        public async Task<CalculoDTO_out> Calcular(PedidoDTO_in ins)
        {

            var list = await CalculoProduccionDTO_out.Calcular(ins, context, mapper);
            var mayor = CalculoProduccionDTO_out.VerMayor(list);

            return new()
            {
                EntregaPedido = mayor,
                CalculoPorElemento = list
            };
        }

        /// <summary>
        /// para almacenar un pedido
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<ActionResult<bool>> Guardar(PedidoDTO_in ins)
        {
            try
            {
                var ent = mapper.Map<Pedido>(ins);
                var us = await context.AspNetUsuario.Where(y => y.Email == User.Identity.Name).FirstOrDefaultAsync();
                if (us == null || us.id < 1)
                    return false;

                ent.Solicitanteid = us.id;
                ent.FechaEntregaPosible = await CalculoProduccionDTO_out.CalcularFechaEntrega(ins, context);

                ent.PedidoProductos = new();

                if (ins.Productos != null || ins.Productos.Count > 0)
                    foreach (var item in ins.Productos)
                    {
                        if (item.Cantidad > 0)
                        {
                            var producto = await Producto.GetByParametersAsync(context, item.Mariscoid, item.TipoProduccionid, item.Calibreid, item.Empaquetadoid);
                            if (producto != null && producto.id > 0)
                                ent.PedidoProductos.Add(new() { Cantidad = item.Cantidad, Productoid = producto.id });
                        }
                    }

                context.Add(ent);
                await context.SaveChangesAsync();
                return true;

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return false;
            }
        }

        #endregion


        #region ver pedidos actuales
        /// <summary>
        /// para ver los pedidos activos actuales
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<PedidoDTOS_out> list = new();
            try
            {

                var ent = await context.Pedidos
                     .Include(ee => ee.Solicitante)
                    .Include(ee => ee.Cliente)
                    .Where(y => y.act == true).ToListAsync();
                list = mapper.Map<List<PedidoDTOS_out>>(ent);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                throw;
            }

            return View(list);
        }

        #endregion

        #region details
        /// <summary>
        /// para obtener los detalles del pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            PedidoDTO_out model = new();

            try
            {
                var ent = await context.Pedidos
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Marisco)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.TipoProduccion)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Calibre)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Empaquetado)
                    .Include(ee => ee.Solicitante)
                    .Include(ee => ee.Cliente)
                    .Where(y => y.id == id).FirstOrDefaultAsync();
                model = mapper.Map<PedidoDTO_out>(ent);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return View(model);
        }

        #endregion

        #region eliminar pedidos
        /// <summary>
        /// para eliminar un pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ent = await context.Pedidos.Where(y => y.id == id).FirstOrDefaultAsync();
                if (ent != null || ent.id == id)
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
