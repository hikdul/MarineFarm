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
                var ents = await context.MateriasPrimas
                    .Include(x => x.Marisco)
                    .Where(x => x.Marisco.act == true && x.Cantidad > 0)
                    .ToListAsync();
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

        /// <summary>
        /// Para exportar un archivo con la data actual
        /// </summary>
        /// <returns></returns>
        public async Task<FileResult> ExcelMateriaPrimaActual()
        {
            
            try
            {
                var ents = await context.MateriasPrimas
                    .Include(x => x.Marisco)
                    .Where(x => x.Marisco.act == true)
                    .ToListAsync();
                var data = mapper.Map<List<MateriaPrimaDTO_out>>(ents);
                var buffer= MateriaPrimaDTO_out.Excel(data);
                return File(buffer, "application/vnd.ms-excel", "Materia Prima actual" + "-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +  ".xlsx");
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return File(new byte[0], "application/vnd.ms-excel", "Empty.xlsx");
            }
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
              //  ViewBag.list = mapper.Map<List<GTipoDTO_out>>( await context.Mariscos.Where(ee => ee.act == true).ToListAsync());
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                throw;
            }

            return View();

        }

        /// <summary>
        /// para almacenar los datos de la nueva materia
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(MateriaPrimaDTO_in ins)
        {
            try
            {
                var resp = await ins.Add(context, mapper);
                HistorialMateriaPrima hs = new(ins.Mariscoid, ins.Cantidad, true);
                await hs.Add(context, User);
                ViewData.Add("Msg", "Elemento Almacenado");
            }
            catch (Exception ee)
            {
                ViewData.Add("Err", "Error al almacenar los datos");
                Console.Error.WriteLine(ee.Message);
            }

            return RedirectToAction("Index");

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

            ViewBag.fi = periodo.Inicio.ToString("yyyy-MM-dd");
            ViewBag.ff = periodo.Fin.ToString("yyyy-MM-dd");
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
        /// <summary>
        /// Para exportar un archivo excel con el historial de un periodo dado
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        public async Task<FileResult> ExcelHistoria(Periodo periodo)
        {
            try
            {

            if (!periodo.Validate())
                periodo = new();

                var hs = await context
                    .HistorialMateriaPrima
                    .Include(x => x.Usuario)
                    .Include(x => x.Marisco)
                    .Where(x => x.Fecha >= periodo.Inicio.AddDays(-1) && x.Fecha <= periodo.Fin.AddDays(1))
                    .ToListAsync();
                var data = mapper.Map<List<HistorialMateriaPrimaDTO_out>>(hs);
                var buffer = HistorialMateriaPrimaDTO_out.Excel(data,periodo);
                return File(buffer, "application/vnd.ms-excel", "Hestorial Materia Prima" +  ".xlsx");
            }
            catch (Exception ee)
            {
                
                Console.WriteLine(ee.Message);
                return File(new byte[0], "application/vnd.ms-excel", "Empty.xlsx");
            }
        }

        #endregion



    }
}