using MarineFarm.Entitys;

namespace MarineFarm.DTO
{
    public class AlmacenDTO
    {
        #region props

        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Cantidad en el almacen
        /// </summary>

        public double Cantidad { get; set; } = 0;

        /// <summary>
        /// Producto
        /// </summary>
        public int Productoid { get; set; }

        /// <summary>
        /// prop nav
        /// </summary>
        public ProductoDTO_out Producto { get; set; }

        #endregion
    }
}
