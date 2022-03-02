using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using MarineFarm.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers.API
{
    /// <summary>
    /// controlador para equipos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : BaseController
    {

        #region ctor
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public EquipoController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #endregion

        #region create
        /// <summary>
        /// para agregar un nuevo turno
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult> Post(EquipoDTO_in ins)
        {
            try
            {

                var entT = mapper.Map<Turnos>(ins.turno);

                context.Add(entT);

                await context.SaveChangesAsync();

                foreach (var item in ins.cargos)
                {
                    var ent = new Equipo()
                    {
                        CantCubierta = item.CantCubierta,
                        Cargoid = item.Cargoid,
                        CostoOperario = item.CostoOperario,
                        Turnoid = entT.id
                    };

                    context.Add(ent);
                }
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("upss, Error inesperado. Intente Mas Tarde");
            }
        }



        #endregion

        #region obtener

        /// <summary>
        /// para obtener una lista de los equipo activos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var turno = await context.Turnos.Where(x => x.act == true).ToListAsync();

                if (turno == null || turno.Count == 0)
                    return NoContent();
                var ent = await context.Equipos
                    .Include(x => x.Cargo)
                    .ToListAsync();

                var retorno = EquipoDTO_out.Up(ent, turno);

                return Ok(retorno);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("upss, algo salio mal");
            }
        }

        /// <summary>
        /// para obtener los detalles de un equipo en particular,
        /// por medio del id de turno
        /// </summary>
        /// <returns></returns>

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var turno = await context.Turnos.Where(x => x.id == id).FirstOrDefaultAsync();
                var ent = await context.Equipos
                    .Include(x => x.Cargo)
                    .Where(x => x.Turnoid == id)
                    .ToListAsync();
                if (turno == null || ent == null || ent.Count == 0)
                    return BadRequest("Datos no Validos");


                var retorno = new EquipoDTO_out(ent, turno);

                return Ok(retorno);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("upss, algo salio mal");
            }
        }


        #endregion

        #region editar
        /// <summary>
        /// Para editar un equipo
        /// en este controlador se envia un correo indicardo que falta personal, si es cierto claro esta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cargos"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, List<__in> cargos)
        {

            try
            {


                foreach (var item in cargos)
                {

                    var ent = await context
                        .Equipos
                        .Where(x => x.Turnoid == id && x.Cargoid == item.Cargoid)
                        .FirstOrDefaultAsync();

                    ent.CantCubierta = item.CantCubierta;
                    ent.CostoOperario = item.CostoOperario;

                    await context.SaveChangesAsync();


                }



                return NoContent();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("upss, Algo Sali mal");
            }
        }


        #endregion

        #region delete
        /// <summary>
        /// para desactivar el uso de un turno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await Delete<Turnos>(id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return BadRequest("No Es Posibre eliminar este elemeno");
            }
        }


        #endregion
    }
}
