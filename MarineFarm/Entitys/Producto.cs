using MarineFarm.Data;
using MarineFarm.Helpers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// Almacena los productos
    /// </summary>
    public class Producto : Iid
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// si esta activo o no en base de datos
        /// </summary>
        public bool act { get; set; } = true;

        // ### de aqui definimos las propiedades del producto
        // ### ===========================

        /// <summary>
        /// Marisco al que pertenece el producto
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public Marisco Marisco { get; set; }

        /// <summary>
        /// tipo de produccion al que se refiere
        /// </summary>
        public int TipoProduccionid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public TipoProduccion TipoProduccion { get; set; }

        /// <summary>
        /// calibre del Tipo de produccion
        /// </summary>
        public int Calibreid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public Calibre Calibre { get; set; }
        /// <summary>
        /// Empaquetado del producto
        /// </summary>
        public int Empaquetadoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Empaquetado Empaquetado { get; set; }
        #endregion

        #region obtener por parametros

        /// <summary>
        /// para obtener el producto en base a sus parametros.
        /// en caso de no existir crea uno
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Mid">marisca</param>
        /// <param name="TPid">tipo de producto</param>
        /// <param name="Cid">Calibre</param>
        /// <param name="Eid">Empaquetado</param>
        /// <returns></returns>
        public static async Task<Producto> GetByParametersAsync(ApplicationDbContext context, int Mid, int TPid, int Cid, int Eid)
        {
            try
            {

              var pp = await context.Productos
                      .Where(x => x.Mariscoid == Mid
                      && x.TipoProduccionid == TPid
                      && x.Calibreid == Cid
                      && x.Empaquetadoid == Eid)
                      .FirstOrDefaultAsync();

                if (pp == null || pp.id < 1)
                {
                    pp = new()
                    {
                        Mariscoid = Mid,
                        TipoProduccionid = TPid,
                        Calibreid = Cid,
                        Empaquetadoid = Eid
                    };
                    context.Add(pp);
                    await context.SaveChangesAsync();
                }
                return pp;

               
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return new();
            }
        }


        #endregion


    }
}
