


using System.ComponentModel.DataAnnotations;
using MarineFarm.DTO;

namespace MarineFarm.Reportes
{
    /// <summary>
    ///     Para Enviar los datos al controlador y generar el reporte 
    /// </summary>
    public class RepotePorPaisDTO_in:Periodo
    {
        /// <summary>
        /// Pais al que se le quiere hacer el estudio
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        /// Marisco del que se quiere hocer el estudio
        /// </summary>
        [Range(0,int.MaxValue)]
        public int Mariscoid { get; set; }
        /// <summary>
        /// Calibre al que se le quiere hacer el estudio
        /// </summary>
        [Range(0,int.MaxValue)]
        public int Calibre { get; set; }
    }
}