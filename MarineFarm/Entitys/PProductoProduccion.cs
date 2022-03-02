using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// Productos usados en produccion
    /// </summary>
    public class PProductoProduccion
    {
        /// <summary>
        /// produccion a la que pertenece
        /// </summary>
        public int Produccionid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Produccion Produccion { get; set; }

        /// <summary>
        /// producto que se produjo
        /// </summary>
        public int Productoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Producto Producto { get; set; }
        /// <summary>
        /// cantidad producida
        /// </summary>
        [Range(0, double.MaxValue)]
        public double CantidadProducida { get; set; }
    }
}
