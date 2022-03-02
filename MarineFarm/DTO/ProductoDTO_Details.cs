using MarineFarm.Entitys;

namespace MarineFarm.DTO
{
    /// <summary>
    /// obtiene un producto con todo sus detalles
    /// </summary>
    public class ProductoDTO_Details
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// si esta activo o no en base de datos
        /// </summary>
        public bool act { get; set; } = true;
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


    }
}
