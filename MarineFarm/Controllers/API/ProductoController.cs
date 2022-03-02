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
    /// controlador para productos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductoController : BaseController
    {
        #region ctor

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ProductoController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
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
        public async Task<IActionResult> Post(ProductoDTO_in insert)
        {

            try
            {
                if (await insert.Validate(context))
                {

                    var ent = mapper.Map<Producto>(insert);

                    context.Add(ent);
                    await context.SaveChangesAsync();

                    ent = await context.Productos
                        .Include(x => x.Marisco)
                        .Include(x => x.TipoProduccion)
                        .Include(x => x.Calibre)
                        .Include(x => x.Empaquetado)
                        .Where(x => x.id == ent.id)
                        .FirstOrDefaultAsync();

                    var ret = mapper.Map<ProductoDTO_out>(ent);

                    return new OkObjectResult(ret);
                }
                return BadRequest("El Producto Ya Existe");
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
                var ent = await context.Productos
                     .Include(x => x.Marisco)
                     .Include(x => x.TipoProduccion)
                     .Include(x => x.Calibre)
                     .Include(x => x.Empaquetado)
                     .Where(x => x.act == true)
                     .ToListAsync();

                var ret = mapper.Map<List<ProductoDTO_out>>(ent);

                return Ok(ret);
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
                var ent = await context.Productos
                    .Include(x => x.Marisco)
                    .Include(x => x.TipoProduccion)
                    .Include(x => x.Calibre)
                    .Include(x => x.Empaquetado)
                    .Where(x => x.id == id)
                    .FirstOrDefaultAsync();

                var ret = mapper.Map<ProductoDTO_out>(ent);

                return new OkObjectResult(ret);
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
        /// actualiza un elemento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="change"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ProductoDTO_in change)
        {
            try
            {

                if (await change.Validate(context))
                    return await Put<ProductoDTO_in, Producto>(id, change);
                return BadRequest("El Producto Ya Existe");
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
        /// elimina un elemento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await Delete<Producto>(id);
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
