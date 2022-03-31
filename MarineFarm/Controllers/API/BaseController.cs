using AutoMapper;
using MarineFarm.Data;
using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Controllers.API
{
    public class BaseController :  ControllerBase
    {

        #region ctor

        // => inyecciones

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public BaseController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        #endregion

        #region Post
        /// <summary>
        /// para retornar una ruta con todo los elementos de lo recien creado
        /// </summary>
        /// <typeparam name="TDTO_in"></typeparam>
        /// <typeparam name="TEntidad"></typeparam>
        /// <typeparam name="TDTO_Out"></typeparam>
        /// <param name="_Insenrt"></param>
        /// <param name="NombreRuta"></param>
        /// <returns></returns>
        protected async Task<ActionResult> Post<TDTO_in, TEntidad, TDTO_Out>(TDTO_in _Insenrt, string NombreRuta) where TEntidad : class, Iid
        {
            try
            {
                var ent = mapper.Map<TEntidad>(_Insenrt);

                context.Add(ent);
                await context.SaveChangesAsync();
                var ret = mapper.Map<TDTO_Out>(ent);

                return new CreatedAtRouteResult(NombreRuta, new { id = ent.id }, ret);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Imposible Guardar sus datos");
            }

        }

        /// <summary>
        /// para retornar un objeto con lo recien creado
        /// </summary>
        /// <typeparam name="TDTO_in"></typeparam>
        /// <typeparam name="TEntidad"></typeparam>
        /// <typeparam name="TDTO_Out"></typeparam>
        /// <param name="_Insenrt"></param>
        /// <returns></returns>
        protected async Task<ActionResult> Post<TDTO_in, TEntidad, TDTO_Out>(TDTO_in _Insenrt) where TEntidad : class
        {
            try
            {
                var ent = mapper.Map<TEntidad>(_Insenrt);

                context.Add(ent);
                await context.SaveChangesAsync();
                var ret = mapper.Map<TDTO_Out>(ent);

                return new OkObjectResult(ret);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Imposible Guardar sus datos");
            }

        }



        #endregion

        #region Get

        /// <summary>
        /// obtiene los datos activos en base de datos
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <typeparam name="TDTO"></typeparam>
        /// <returns></returns>
        protected async Task<List<TDTO>> Get<TEntidad, TDTO>() where TEntidad : class, Iid
        {
            try
            {
                var ent = await context.Set<TEntidad>().Where(i => i.act == true).AsNoTracking().ToListAsync();
                return mapper.Map<List<TDTO>>(ent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }
        }


        /// <summary>
        /// obtiene los datos activos en base de datos
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <typeparam name="TDTO"></typeparam>
        /// <returns></returns>
        protected async Task<List<TDTO>> GetAll<TEntidad, TDTO>() where TEntidad : class
        {
            try
            {
                var ent = await context.Set<TEntidad>().AsNoTracking().ToListAsync();
                return mapper.Map<List<TDTO>>(ent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }
        }


        /// <summary>
        /// obtiene un dato por medio de su id
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <typeparam name="TDTO_out"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        protected async Task<TDTO_out> Get<TEntidad, TDTO_out>(int id) where TEntidad : class, Iid where TDTO_out : class, new()
        {
            try
            {
                var ent = await context.Set<TEntidad>().AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
                return mapper.Map<TDTO_out>(ent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }
        }


        #endregion

        #region PUT
        /// <summary>
        /// update
        /// </summary>
        /// <typeparam name="TDTO_in"></typeparam>
        /// <typeparam name="TEntidad"></typeparam>
        /// <param name="id"></param>
        /// <param name="insert"></param>
        /// <returns></returns>
        protected async Task<ActionResult> Put<TDTO_in, TEntidad>(int id, TDTO_in insert) where TEntidad : class, Iid
        {
            try
            {
                var original = await context.Set<TEntidad>().FirstOrDefaultAsync(x => x.id == id);
                if (original == null)
                    return NotFound();

                original = mapper.Map(insert, original);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Imposible Editar sus datos");
            }
        }

        #endregion

        #region Delete
        /// <summary>
        /// para "eliminar elementos" de la tabla
        /// mas bien pasan al estado de inactivos
        /// </summary>
        /// <typeparam name="TEntidad"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        protected async Task<ActionResult> Delete<TEntidad>(int id) where TEntidad : class, Iid
        {
            try
            {
                var original = await context.Set<TEntidad>().FirstOrDefaultAsync(x => x.id == id);
                if (original == null)
                    return NotFound();

                original.act = false;
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Algo Salio Mal, Imposible Eliminar sus datos");
            }
        }

        #endregion


    }
}
