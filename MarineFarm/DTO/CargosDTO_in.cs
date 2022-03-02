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
    }
}
