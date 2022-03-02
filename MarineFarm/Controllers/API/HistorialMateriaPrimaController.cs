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
    /// datos para obtener el historial para materia prima
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HistorialMateriaPrimaController : ControllerBase
    {

        #region ctor

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public HistorialMateriaPrimaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        #endregion

        #region ver historial

        /// <summary>
        /// para ver el esturial en un periodo predeterminado
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Historial([FromBody] Periodo periodo)
        {
            try
            {

                var hs = await context
                    .HistorialMateriaPrima
                    .Include(x => x.Usuario)
                    .Include(x => x.Marisco)
                    .Where(x => x.Fecha >= periodo.Inicio.AddDays(-1) && x.Fecha <= periodo.Fin.AddDays(1))
                    .ToListAsync();
                return Ok(mapper.Map<List<HistorialMateriaPrimaDTO_out>>(hs));

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return BadRequest("Upss, Algo Salio mal intente mas tarde");
            }
        }
        #endregion


    }
}
