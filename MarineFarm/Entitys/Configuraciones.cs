using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// para mantener la configuracion desde el sistema.
    /// lo ideal seria desde un archivo json pero como esta son configuraciones por consulta ontonces no hay problema
    /// </summary>
    public class Configuraciones
    {

        /// <summary>
        /// element required for the database
        /// </summary>
        [Key]
        public int id { get; set; }

        // ================= ##
        // Tiempos Produccion
        // ================= ##

        /// <summary>
        /// Dias habiles
        /// </summary>
        public int DiasHabiles { get; set; }
        /// <summary>
        /// produccion default para un dia
        /// </summary>
        public double ProduccionDefaultPorDia { get; set; }

        
    }
}
