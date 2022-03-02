namespace MarineFarm.DTOs
{
    public class DatosProduccion_out
    {
        /// <summary>
        /// marisco que se utilizo
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Cantidad de materia prima utilizada
        /// </summary>
        public double CantUsada { get; set; }
        /// <summary>
        /// datos de productos realizados
        /// </summary>
        public List<DatosProduccionProductos_out> Productos { get; set; }


    }
}
