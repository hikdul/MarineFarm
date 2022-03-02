using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers.API
{
    /// <summary>
    /// controlador para almacen
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlmacenController : ControllerBase
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

        #region add

        /// <summary>
        /// para adicionar elementos
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ActionResult> Add(AlmacenDTO_in ins)
        {
            try
            {

                return Ok(await ins.Add(context, mapper));

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Intente mas tarde");

            }
        }





        #endregion

        #region  substract

        /// <summary>
        /// para quitar elementos
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPost("Substract")]
        public async Task<ActionResult> Substract(AlmacenDTO_in ins)
        {
            try
            {
                return Ok(await ins.Substract(context, mapper));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Intente mas tarde");

            }
        }

        #endregion

        #region Get

        /// <summary>
        /// para obtener un listado de todos los elementos en almacen
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {

                var ents = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x => x.Cantidad > 0)
                    .ToListAsync();

                return Ok(mapper.Map<List<AlmacenDTO_out>>(ents));

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("algo salio mal, intente luego");
            }
        }


        /// <summary>
        /// para obtener los datos en detalles de un elemento en particular
        /// por medio de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x => x.id == id)
                    .FirstOrDefaultAsync();

                return Ok(mapper.Map<AlmacenDTO>(ent));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("algo salio mal, intente luego");
            }
        }


        #endregion
    }
}
