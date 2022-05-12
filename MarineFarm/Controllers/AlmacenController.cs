using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers
{
    /// <summary>
    /// para controlar los datos del almacen de productos finales
    /// </summary>
    public class AlmacenController : Controller
    {


        #region ctor

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public AlmacenController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region vista principal 

        /// <summary>
        /// vista de los datos actuales
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<AlmacenDTO_out> list = new();
            try
            {

                var ents = await AlmacenDTO_out.Listar(context,mapper);
                list = mapper.Map<List<AlmacenDTO_out>>(ents);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }


            return View(list);
        }


        #endregion

      #region  excel

        /// <summary>
        /// Para exportar los datos del almacen actualr en un excel
        /// </summary>
        /// <returns></returns>
        public async Task<FileResult> Excel()
        {
            try
            {
                var data= await AlmacenDTO_out.Listar(context,mapper);
                var buffer= AlmacenDTO_out.Excel(data);
                return File(buffer, "application/vnd.ms-excel", "Almacen Actual" + "-" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".xlsx");
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
