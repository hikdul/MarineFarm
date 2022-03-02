namespace MarineFarm.DTOs
{
    /// <summary>
    /// para enviar los datos de la produccion
    /// </summary>
    public class ProduccionDTO_out
    {

        public int id { get; set; }
        /// <summary>
        /// fecha en que fue realizado la produccion
        /// </summary>
        public DateTime Fecha { get; set; }
        /// <summary>
        /// quien esta a cargo de la produccion
        /// </summary>
        public string SupervName { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string SupervEmail { get; set; }

        /// <summary>
        /// detalles de lo producido
        /// </summary>
        public List<DatosProduccion_out> productos { get; set; }



    }
}
