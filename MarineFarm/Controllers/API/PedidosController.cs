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
    /// controlador para manipular los datos de los pedidos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PedidosController : BaseController
    {

        #region ctor
        
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public PedidosController( ApplicationDbContext context, IMapper mapper) : base(context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion

        #region Obtener datos
        /// <summary>
        /// para obtener un listado de pedidos en base al rol del usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            try
            {
                if (User.IsInRole("Cliente"))
                {
                    return Ok();
                }

                var ents = await context.Pedidos
                    .Include(ee => ee.Solicitante)
                    .Include(ee => ee.Cliente)
                    .Where(x => x.act == true)
                    .ToListAsync();

                return Ok(mapper.Map<List<PedidoDTOS_out>>(ents));
            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
                return BadRequest("Alga Salio mal, intente mas tarde");
            }


        }

        /// <summary>
        /// para obtener una lista de pedidos en un periodo valido
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        [HttpPost("Historial")]
        public async Task<ActionResult> Historial([FromBody] Periodo periodo)
        {
            if (!periodo.Validate())
                return BadRequest("Fechas no validas");

            try
            {
                var hs = await context.Pedidos
                    .Where(ee => ee.FechaSolicitud >= periodo.Inicio && ee.FechaSolicitud <= periodo.Fin)
                    .ToListAsync();

                return Ok(mapper.Map<List<PedidoDTOS_out>>(hs));

            }
            catch (Exception ee)
            {
                return BadRequest("Upps, algo salio mal. Por favor intente mas tarde.");
            }


        }

        #endregion


    }
}
