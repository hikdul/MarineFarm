using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTOs
{

    /// <summary>
    /// para insertar un nuevo producto
    /// </summary>
    public class ProductoDTO_in
    {

        #region props

        /// <summary>
        /// Marisco al que pertenece el producto
        /// </summary>
        public int Mariscoid { get; set; }

        /// <summary>
        /// tipo de produccion al que se refiere
        /// </summary>
        public int TipoProduccionid { get; set; }

        /// <summary>
        /// calibre del Tipo de produccion
        /// </summary>
        public int Calibreid { get; set; }
        /// <summary>
        /// Empaquetado del producto
        /// </summary>
        public int Empaquetadoid { get; set; }
        #endregion


        #region validate

        /// <summary>
        /// para validar si un elemento es viable de crear
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public  async Task<bool> Validate(ApplicationDbContext context)
        {
            try
            {

                var ent = await context.Productos.Where(x =>
                x.Calibreid == this.Calibreid
                && x.Empaquetadoid == this.Empaquetadoid
                && x.Mariscoid == this.Mariscoid
                && x.TipoProduccionid == this.TipoProduccionid).FirstOrDefaultAsync();

                return ent == null || ent.id <= 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        #endregion

    }
}
