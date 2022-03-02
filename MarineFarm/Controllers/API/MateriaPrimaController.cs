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
    /// Controlador para la materia prima
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MateriaPrimaController : ControllerBase
    {

        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public MateriaPrimaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion

        #region add
        /// <summary>
        /// para agregar datos a la materia prima
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>

        [HttpPost("add")]
        public async Task<ActionResult> Add(MateriaPrimaDTO_in ins)
        {
            try
            {

                var resp = await ins.Add(context, mapper);
                HistorialMateriaPrima hs = new(ins.Mariscoid, ins.Cantidad, true);
                await hs.Add(context, User);

                if (resp != null && resp.id > 0)
                    return Ok(resp);
                return BadRequest("Datos No Validos. Verifique la informacion ingresada");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Intente mas tarde");
            }
        }



        #endregion

        #region Substract
        /// <summary>
        /// para agregar datos a la materia prima
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>

        [HttpPost("Substract")]
        public async Task<ActionResult> Substract(MateriaPrimaDTO_in ins)
        {
            try
            {

                var resp = await ins.Substract(context, mapper);

                HistorialMateriaPrima hs = new(ins.Mariscoid, ins.Cantidad, false);
                await hs.Add(context, User);

                if (resp != null && resp.id > 0)
                    return Ok(resp);

                return BadRequest("Datos No Validos. Verifique la informacion ingresada");

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
        /// obtiene todo el listado de materias primas
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var ents = await context.MateriasPrimas.Include(x => x.Marisco).ToListAsync();
                return Ok(mapper.Map<List<MateriaPrimaDTO_out>>(ents));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Intente mas tarde");
            }
        }

        /// <summary>
        /// obtiene los datos de 1 elemento en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var ent = await context.MateriasPrimas
                    .Include(x => x.Marisco)
                    .Where(x => x.id == id).FirstOrDefaultAsync();
                return Ok(mapper.Map<MateriaPrimaDTO>(ent));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Intente mas tarde");
            }
        }



        #endregion

    }

}
