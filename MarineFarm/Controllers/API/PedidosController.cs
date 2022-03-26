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
        /// para obtener los datos de un pedido a detalle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var ent = await context.Pedidos
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Marisco)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.TipoProduccion)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Calibre)
                    .Include(y => y.PedidoProductos).ThenInclude(y => y.Producto).ThenInclude(y => y.Empaquetado)
                    .Include(ee => ee.Solicitante)
                    .Include(ee => ee.Cliente)
                    .Where(x =>
                    x.act == true &&
                    x.id == id)
                    .FirstOrDefaultAsync();
                return Ok(mapper.Map<PedidoDTO_out>(ent));
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

        #region post
        /// <summary>
        /// para generar un nuevo pedido
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PedidoDTO_in ins)
        {
            try
            {
                var ent = mapper.Map<Pedido>(ins);
                var us = await context.AspNetUsuario.Where(y => y.Email == User.Identity.Name).FirstOrDefaultAsync();
                if (us == null || us.id < 1)
                    return BadRequest("Usuario No Valido");

                ent.Solicitanteid = us.id;
                ent.FechaEntregaPosible = DateTime.Now.AddDays(10);

                ent.PedidoProductos = new();

                if (ins.Productos != null || ins.Productos.Count > 0)
                    foreach (var item in ins.Productos)
                    {
                        if (item.Cantidad > 0)
                        {
                            var producto = await Producto.GetByParametersAsync(context, item.Mariscoid, item.TipoProduccionid, item.Calibreid, item.Empaquetadoid);
                            if (producto != null && producto.id > 0)
                                ent.PedidoProductos.Add(new() { Cantidad = item.Cantidad, Productoid = producto.id });
                        }
                    }

                context.Add(ent);
                await context.SaveChangesAsync();
                return Ok(mapper.Map<PedidoDTOS_out>(ent));
            
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return BadRequest("upss, error al insertar datos. por favor intente de nuevo mas tarde");
            }
        }

        #endregion
    }
}
