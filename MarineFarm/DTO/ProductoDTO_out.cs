using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para mostrar los datos generales sobre un producto en si.
    /// </summary>
    public class ProductoDTO_out
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

        /// <summary>
        /// marisco
        /// </summary>
        public string Marisco { get; set; }

        /// <summary>
        /// tipo de produccion
        /// </summary>
        public string TipoProduccion { get; set; }

        /// <summary>
        /// calibre
        /// </summary>
        public string Calibre { get; set; }
        /// <summary>
        /// empaquetado
        /// </summary>
        public string Empaquetado { get; set; }
        #endregion
    }
}
