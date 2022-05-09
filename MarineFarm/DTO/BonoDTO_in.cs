using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para crear/editar un bono
    /// </summary>
    public class BonoDTO_in : GTipoDTO_in
    {
        /// <summary>
        /// Cantidad de kilogramos a pagar
        /// </summary>
        [Range(1,double.MaxValue)]
        public double Kilogramos { get; set; }
        /// <summary>
        /// Cantidad a pagar por los kilogramos obtenidos
        /// </summary>
        [Range(1,double.MaxValue)]
        public double Pago { get; set; }

    }
}
