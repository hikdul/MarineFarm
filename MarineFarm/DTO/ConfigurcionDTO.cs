namespace MarineFarm.DTO
{
    /// <summary>
    /// para mostrar los datos de configuracion
    /// </summary>
    public class ConfigurcionDTO
    {
        /// <summary>
        /// element required for the database
        /// </summary>
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

        // ================= ##
        // Bono de produccion
        // ================= ##

        /// <summary>
        /// cantidad de kg para el bono
        /// </summary>
        public double KgBono { get; set; }
        /// <summary>
        /// cantidad a pagar por los kilogramos producidos
        /// </summary>
        public double PagoBono { get; set; }
    }
}
