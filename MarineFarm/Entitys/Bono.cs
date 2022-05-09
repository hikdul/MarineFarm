using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// esta clase es para generar los bonos que usa la aplicacion
    /// </summary>
    public class Bono: ITipo
    {
        #region props
        /// <summary>
        /// nombre del bono
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// breve descripcion de a quien aplica el bono
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// id en base de datos
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// si el bono se encuentra o no activo
        /// </summary>
        public bool act { get; set; }
        /// <summary>
        /// Cantidad de kilogramos a pagar
        /// </summary>
        public double Kilogramos { get; set; }
        /// <summary>
        /// Cantidad a pagar por los kilogramos obtenidos
        /// </summary>
        public double Pago { get; set; }
        #endregion

        #region calculo

        /// <summary>
        /// calcula el pago en base a los datos administrados sobre el bono
        /// </summary>
        /// <param name="kgProduccion"></param>
        /// <returns></returns>
        public double Calcular(double kgProduccion)
        {
            if (kgProduccion < this.Kilogramos)
                return 0;

            return kgProduccion / this.Kilogramos * Pago;
        }
        
        #endregion

    }
}
