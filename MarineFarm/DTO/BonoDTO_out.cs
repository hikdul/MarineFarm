

using MarineFarm.DTO;
/// <summary>
///  Para entregar estos datos al usuario 
/// </summary>
public class BonoDTO_out:GTipoDTO_out
{

        /// <summary>
        /// Cantidad de kilogramos a pagar
        /// </summary>
        public double Kilogramos { get; set; }
        /// <summary>
        /// Cantidad a pagar por los kilogramos obtenidos
        /// </summary>
        public double Pago { get; set; }

}