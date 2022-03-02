using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.Controllers.API
{
    /// <summary>
    /// controlador para calibres
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CalibreController : BaseController
    {
        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CalibreController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        #endregion

        #region Post
        /// <summary>
        /// para almacenar un nuevo marisco
        /// </summary>
        /// <param name="insert"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Post(GTipoDTO_in insert)
        {

            try
            {
                return await Post<GTipoDTO_in, Calibre, GTipoDTO_out>(insert);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("error al almacenar datos. Verifique nuevamente");
            }

        }

        #endregion

        #region Get


        /// <summary>
        /// obtiene listado de activos
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resp = await Get<Calibre, GTipoDTO_out>();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("error al Obtener los datos");
            }
        }

        /// <summary>
        /// obtiene datos de 1 unico elemento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resp = await Get<Calibre, GTipoDTO_out>(id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("error al Obtener los datos");
            }
        }



        #endregion

        #region Put
        /// <summary>
        /// edita el elemento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="change"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, GTipoDTO_in change)
        {
            try
            {
                return await Put<GTipoDTO_in, Calibre>(id, change);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("error al editar los datos. Verifique nuevamente");
            }
        }

        #endregion

        #region Delete
        /// <summary>
        /// elimina el elemento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await Delete<Calibre>(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("No Es Posible Borrar el Elemento");
            }
        }


        #endregion
    }
}
