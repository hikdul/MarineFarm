using AutoMapper;
using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para el ingreso de datos
    /// </summary>
    public class AlmacenDTO_in
    {
        #region props
        /// <summary>
        /// Cantidad de kg
        /// </summary>
        [Range(0, double.MaxValue)]
        public double Cantidad { get; set; } = 0;
        /// <summary>
        /// Marisco
        /// </summary>
        [Required]
        public int Marisco { get; set; }
        /// <summary>
        /// Tipo de produccion
        /// </summary>
        [Required]
        public int TipoProduccion { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        [Required]
        public int Calibre { get; set; }
        /// <summary>
        /// Empaquetado
        /// </summary>
        [Required]
        public int Empaquetado { get; set; }
        #endregion


        #region ctor

        /// <summary>
        /// empty
        /// </summary>
        public AlmacenDTO_in()
        {

        }

        /// <summary>
        /// complete
        /// </summary>
        /// <param name="m"></param>
        /// <param name="ty"></param>
        /// <param name="c"></param>
        /// <param name="e"></param>
        /// <param name="cant"></param>
        public AlmacenDTO_in(int m, int ty, int c, int e, double cant)
        {
            this.Marisco = m;
            this.TipoProduccion = ty;
            this.Calibre = c;
            this.Empaquetado = e;
            this.Cantidad = cant;
        }
        /// <summary>
        /// para poder usar el contexto y crear un elemento particular
        /// </summary>
        /// <param name="context"></param>
        /// <param name="productoid"></param>
        /// <param name="cant"></param>
        /// <returns></returns>
        public static async Task<AlmacenDTO_in> costructor(ApplicationDbContext context, int productoid, double cant = 0)
        {
            try
            {
                var prod = await context
                    .Productos
                    .Where(x => x.id == productoid)
                    .FirstOrDefaultAsync();

                if (prod == null || prod.id != productoid)
                    return new();

                return new(prod.Mariscoid, prod.TipoProduccionid, prod.Calibreid, prod.Empaquetadoid, cant);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return new();
            }
        }


        #endregion


        #region add
        /// <summary>
        /// para agregar valores
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public async Task<AlmacenDTO_out> Add(ApplicationDbContext context, IMapper mapper)
        {

            try
            {

                var ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x =>
                x.Producto.Mariscoid == this.Marisco
                && x.Producto.TipoProduccionid == this.TipoProduccion
                && x.Producto.Calibreid == this.Calibre
                && x.Producto.Empaquetadoid == this.Empaquetado
                ).FirstOrDefaultAsync();

                if (ent != null && ent.id > 0)
                {
                    ent.Cantidad += this.Cantidad;
                    await context.SaveChangesAsync();
                    return mapper.Map<AlmacenDTO_out>(ent);
                }

                var producto = await context.Productos.Where(x =>
                x.Calibreid == this.Calibre
                && x.Mariscoid == this.Marisco
                && x.TipoProduccionid == this.TipoProduccion
                && x.Empaquetadoid == this.Empaquetado
                ).FirstOrDefaultAsync();



                if (producto == null || producto.id < 1)
                {
                    producto = new()
                    {
                        act = true,
                        Calibreid = this.Calibre,
                        Empaquetadoid = this.Empaquetado,
                        Mariscoid = this.Marisco,
                        TipoProduccionid = this.TipoProduccion,

                    };

                    context.Add(producto);
                    await context.SaveChangesAsync();

                }

                ent = new()
                {
                    Productoid = producto.id,
                    Cantidad = this.Cantidad
                };

                context.Add(ent);
                await context.SaveChangesAsync();

                ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x => x.id == ent.id)
                    .FirstOrDefaultAsync();

                return mapper.Map<AlmacenDTO_out>(ent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }

        }



        #endregion



        #region substract
        /// <summary>
        /// resta
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public async Task<AlmacenDTO_out> Substract(ApplicationDbContext context, IMapper mapper)
        {

            try
            {

                var ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x =>
                x.Producto.Mariscoid == this.Marisco
                && x.Producto.Calibreid == this.Calibre
                && x.Producto.TipoProduccionid == this.TipoProduccion
                && x.Producto.Empaquetadoid == this.Empaquetado
                ).FirstOrDefaultAsync();

                if (ent != null && ent.id > 0)
                {
                    ent.Cantidad -= this.Cantidad;
                    if (ent.Cantidad < 0)
                        ent.Cantidad = 0;
                    await context.SaveChangesAsync();
                    return mapper.Map<AlmacenDTO_out>(ent);
                }

                var producto = await context.Productos.Where(x =>
                x.Calibreid == this.Calibre
                && x.Mariscoid == this.Marisco
                && x.TipoProduccionid == this.TipoProduccion
                && x.Empaquetadoid == this.Empaquetado
                ).FirstOrDefaultAsync();



                if (producto == null || producto.id < 1)
                {
                    producto = new()
                    {
                        act = true,
                        Calibreid = this.Calibre,
                        Empaquetadoid = this.Empaquetado,
                        Mariscoid = this.Marisco,
                        TipoProduccionid = this.TipoProduccion,

                    };

                    context.Add(producto);
                    await context.SaveChangesAsync();

                }

                ent = new()
                {
                    Productoid = producto.id,
                    Cantidad = 0
                };

                context.Add(ent);
                await context.SaveChangesAsync();

                ent = await context.Almacen
                    .Include(a => a.Producto).ThenInclude(x => x.Marisco)
                    .Include(a => a.Producto).ThenInclude(x => x.TipoProduccion)
                    .Include(a => a.Producto).ThenInclude(x => x.Calibre)
                    .Include(a => a.Producto).ThenInclude(x => x.Empaquetado)
                    .Where(x => x.id == ent.id)
                    .FirstOrDefaultAsync();

                return mapper.Map<AlmacenDTO_out>(ent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new();
            }

        }

        #endregion
    }
}
