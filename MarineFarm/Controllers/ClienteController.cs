﻿using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// controlador de clientes
    /// </summary>
    public class ClienteController : Controller
    {
        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ClienteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region vista principal
        /// <summary>
        /// para obtener un listado de los cliente actuales
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<ClienteDTO_out> model = new();
            try
            {
                if (User.IsInRole("Cliente") || User.IsInRole("Superv"))
                    return RedirectToAction("logout", "Cuentas");

                var ent = await context.Clientes.Where(y => y.act).ToListAsync();
                model = mapper.Map<List<ClienteDTO_out>>(ent);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
               
            }

            return View(model);
        }

        #endregion


        #region CrearCliente

        /// <summary>
        /// vista para crear un cliente
        /// </summary>
        /// <returns></returns>
        public IActionResult Crear()
        {
            if (User.IsInRole("Cliente") || User.IsInRole("Superv"))
                return RedirectToAction("logout", "Cuentas");

            return View();
        }

        /// <summary>
        /// Vista para almacenar los datos de un cliente
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Guardar(ClienteDTO_in ins)
        {
            if (User.IsInRole("Cliente") || User.IsInRole("Superv"))
                return RedirectToAction("logout", "Cuentas");

            try
            {
                var ent = mapper.Map<Cliente>(ins);
                context.Add(ent);
                await context.SaveChangesAsync();
                ViewBag.Msg = "Cliente Creado";
                return RedirectToAction("Index");

            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                ViewBag.Err = "Datos no validos";
                return RedirectToAction("Index");
            }
        }


        #endregion


    }
}
