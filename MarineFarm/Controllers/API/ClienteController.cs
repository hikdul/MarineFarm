using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers.API
{
    /// <summary>
    /// controlador de los datos de clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : BaseController
    {


        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ClienteController(ApplicationDbContext context, IMapper mapper) : base(context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion



        #region post
        /// <summary>
        /// para ingresar un nuevo cliente
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(ClienteDTO_in ins)
        {
            try
            {
                return await Post<ClienteDTO_in, Cliente, ClienteDTO_out>(ins);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return BadRequest("Upss, Algo Salio Mal, intente De nuevo mas tarde");
            }

        }


        #endregion

        #region Put
        /// <summary>
        /// para actualizar los datos de un cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, ClienteDTO_in ins)
        {
            try
            {
                return await Put<ClienteDTO_in, Cliente>(id, ins);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return BadRequest("Error al actualizar los datos. intente mas tarde");
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// para eliminar algun elemento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await Delete<Cliente>(id);
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return BadRequest("No es posible eliminar el elemento. Intente luego");
            }
        }

        #endregion


        #region Get
        /// <summary>
        /// para obtener el listado de elementos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok( await Get<Cliente, ClienteDTO_out>());
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return BadRequest("Upps, error inesperado. intente mas tarde.");
            }
        }

        /// <summary>
        /// para obtener los datos de un cliente en especial
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await Get<Cliente, ClienteDTO_out>(id));
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return BadRequest("Upps, error inesperado. intente mas tarde.");
            }
        }

        #endregion


    }
}
