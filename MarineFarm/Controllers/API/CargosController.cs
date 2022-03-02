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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CargosController : BaseController
    {

        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CargosController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion


        #region post
        /// <summary>
        /// para agregar un nuevo elemento
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CargosDTO_in ins)
        {
            try
            {
                return await Post<CargosDTO_in, Cargos, CargosDTO_out>(ins);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("algo salio mal intente mas tarde");
            }
        }



        #endregion

        #region get

        /// <summary>
        /// obtiene el listado de cargos activos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await Get<Cargos, CargosDTO_out>());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("algo salio mal intente mas tarde");
            }
        }

        /// <summary>
        /// obtiene los datos de un cargo por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await Get<Cargos, CargosDTO_out>(id));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("algo salio mal intente mas tarde");
            }
        }

        #endregion


        #region put

        /// <summary>
        /// actualiza un cargo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CargosDTO_in ins)
        {

            try
            {
                return await Put<CargosDTO_in, Cargos>(id, ins);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("algo salio mal intente mas tarde");
            }
        }




        #endregion


        #region Detele
        /// <summary>
        /// inactiva un cargo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await Delete<Cargos>(id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("algo salio mal intente mas tarde");
            }
        }

        #endregion
    }
}
