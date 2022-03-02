using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTOs
{
    /// <summary>
    /// datos necesario para predecir una fecha de entrega.
    /// estos datos son solo por producto
    /// </summary>
    public class CalcularFechaDTO_in
    {

        /// <summary>
        /// marisco
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Mariscoid { get; set; }
        /// <summary>
        /// Calibreid
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Calibreid { get; set; }
        /// <summary>
        /// Tipo produccion
        /// </summary>
        [Range(1,int.MaxValue)]
        public int TipoProduccionid { get; set; }
        /// <summary>
        /// equipo que va a producir 
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Equipoid { get; set; }
        /// <summary>
        /// cantidad en kilogramos
        /// </summary>
        public double CantKg { get; set; }

    }
}
