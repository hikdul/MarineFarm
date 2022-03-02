namespace MarineFarm.DTO
{
    /// <summary>
    /// para mostrar los elementos
    /// </summary>
    public class CargosDTO_out: GTipoDTO_out
    {
        /// <summary>
        /// Cantidad Operadores Necesaria
        /// </summary>
        public int CantOperadoresNecesario { get; set; } = 1;
    }
}
