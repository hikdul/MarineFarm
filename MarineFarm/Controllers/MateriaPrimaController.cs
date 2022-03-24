﻿using AutoMapper;
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
    /// Para definir los usos de la materia prima
    /// </summary>
    [Authorize]
    public class MateriaPrimaController : Controller
    {


        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public MateriaPrimaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion


        #region listado actual
        /// <summary>
        /// obtiene el listado de la materias primas actuales
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<MateriaPrimaDTO_out> ret = new();
            try
            {
                var ents = await context.MateriasPrimas.Include(x => x.Marisco).ToListAsync();
                ret = mapper.Map<List<MateriaPrimaDTO_out>>(ents);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                throw;
            }
        
            return View(ret);
        }


        /// <summary>
        /// para almacenar el ingreso de elementos
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>

        public async Task<bool> Add(MateriaPrimaDTO_in ins)
        {
            try
            {

                var resp = await ins.Add(context, mapper);
                HistorialMateriaPrima hs = new(ins.Mariscoid, ins.Cantidad, true);
                await hs.Add(context, User);

                if (resp != null && resp.id > 0)
                    return true;
                ViewBag.Err = "Datos No Validos. Verifique la informacion ingresada";

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                ViewBag.Err = "Algo Salio Mal, Intente mas tarde";
            }
            return false;
        }



        #endregion


        #region ingreso

        /// <summary>
        /// vista para generar ingreso de las materias primas
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Ingreso()
        {
            try
            {
                ViewBag.listado = await ToSelect.ToSelectITipo<Marisco>(context);
                ViewBag.list = mapper.Map<List<GTipoDTO_out>>( await context.Mariscos.Where(ee => ee.act == true).ToListAsync());
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                throw;
            }

            return View();

        }


        #endregion


        #region historial

        /// <summary>
        /// para obtener los datos basados en un periodo
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>

        public async Task<IActionResult> Historial(Periodo periodo)
        {
            if (!periodo.Validate())
                periodo = new();

            List<HistorialMateriaPrimaDTO_out> list = new();

            try
            {
                var hs = await context
                    .HistorialMateriaPrima
                    .Include(x => x.Usuario)
                    .Include(x => x.Marisco)
                    .Where(x => x.Fecha >= periodo.Inicio.AddDays(-1) && x.Fecha <= periodo.Fin.AddDays(1))
                    .ToListAsync();
                list = mapper.Map<List<HistorialMateriaPrimaDTO_out>>(hs);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }

            return View(list);

        }



        #endregion



    }
}