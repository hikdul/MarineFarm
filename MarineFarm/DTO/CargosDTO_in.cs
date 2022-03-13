using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para generar nuevos cargos
    /// </summary>
    public class CargosDTO_in: GTipoDTO_in
    {
        /// <summary>
        /// Cantidad Operadores Necesaria
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CantOperadoresNecesario { get; set; } = 1;
        /// <summary>
        /// para indicar el sexo del operador
        /// </summary>
        [Range(0, 2)]
        public int sexo { get; set; } = 0;
    }
}
