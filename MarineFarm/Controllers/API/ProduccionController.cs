using AutoMapper;
using MarineFarm.Auth;
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
    /// controller para produccion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProduccionController : BaseController
    {
        #region ctor
        private readonly ApplicationDbContext context;

        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ProduccionController(ApplicationDbContext context, IMapper mapper): base(context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        #endregion

        #region post

        /// <summary>
        /// para crear una nueva produccion
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProduccionDTO_in ins)
        {

            try
            {

                //valida y en caso de no ser valido retorna la data
                var valid = await ins.inValid(context);

                if (valid == null || valid.Count == 0)
                {
                    var flagUs = await Usuario.GetByEmail(User.Identity.Name, context);

                    if (flagUs == null || flagUs.id < 1)
                        return BadRequest("Usuario no valida para ejecutar esta accion");

                    //generar entidad
                    var ent = await Produccion.Up(ins, flagUs.id, context);


                    //almacena los datos de produccion
                    context.Add(ent);
                    await context.SaveChangesAsync();

                    //todo bien ahora tocamos materia prima 

                    foreach (var item in ent.MariscosProduccion)
                    {
                        MateriaPrimaDTO_in aux = new()
                        {
                            Cantidad = item.CantidadUtilizada,
                            Mariscoid = item.Mariscoid
                        };
                        var bb = await aux.Substract(context, mapper);
                    }
                    //y por ultimo tocamos el almacen

                    foreach (var item in ent.ProductoProduccion)
                    {
                        var aux = await AlmacenDTO_in.costructor(context, item.Productoid, item.CantidadProducida);
                        await aux.Add(context, mapper);
                    }

                    // da respuesta con el resultado obtenido pero mapeado a otro elemento
                    return Ok();
                }
                else
                    return BadRequest(valid);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest("Error Inesperado, intente mas tarde");
            }
        }

        #endregion

        #region Get
        /// <summary>
        /// para obtener los detalles de una produccion especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {

                var ent = await context.Produccion.Where(x => x.Fecha.Year > 2000)
                    .Include(x => x.Superv)
                    .Include(x => x.MariscosProduccion).ThenInclude(x => x.Marisco)
                    .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Marisco)
                    .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Calibre)
                    .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x => x.id == id)
                    .FirstOrDefaultAsync();

                var dto = mapper.Map<ProduccionDTO_out>(ent);

                return Ok(dto);

            }
            catch (Exception eb)
            {
                Console.Error.WriteLine(eb.Message);
                return BadRequest("Error Inesperado, intente mas tarde");
            }
        }
        /// <summary>
        /// para obtener los detalles de toda lo produccion en un periodo especifico
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        [HttpPost("periodo")]
        public async Task<ActionResult> Get(Periodo periodo)
        {
            try
            {
                if (periodo.Validate())
                {

                    var ent = await context.Produccion
                        .Where(x => x.Fecha > periodo.Inicio.AddDays(-1) && x.Fecha < periodo.Fin.AddDays(1))
                        .Include(x => x.Superv)
                        .Include(x => x.MariscosProduccion).ThenInclude(x => x.Marisco)
                        .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Marisco)
                        .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.TipoProduccion)
                        .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Calibre)
                        .Include(x => x.ProductoProduccion).ThenInclude(x => x.Producto).ThenInclude(x => x.Empaquetado)
                        .ToListAsync();

                    var dto = mapper.Map<List<ProduccionDTO_out>>(ent);

                    return Ok(dto);
                }
                return BadRequest("Fechas No Validas");

            }
            catch (Exception eb)
            {
                Console.Error.WriteLine(eb.Message);
                return BadRequest("Error Inesperado, intente mas tarde");
            }
        }
        #endregion

    }
}
