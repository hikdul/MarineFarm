using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// almacena los datos del almacen
    /// </summary>
    public class Almacen
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Cantidad en el almacen
        /// </summary>

        [Range(0, double.MaxValue)]
        public double Cantidad { get; set; } = 0;

        /// <summary>
        /// Producto
        /// </summary>
        public int Productoid { get; set; }

        /// <summary>
        /// prop nav
        /// </summary>
        public Producto Producto { get; set; }

        #endregion
    }
}
