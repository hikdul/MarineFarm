namespace MarineFarm.DTO
{
    public class AlmacenDTO_out
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Cantidad en almacen
        /// </summary>
        public double Cantidad { get; set; } = 0;
        /// <summary>
        /// Marisco
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Tipo de produccion
        /// </summary>
        public string TipoProduccion { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        public string Calibre { get; set; }
        /// <summary>
        /// Empaquetado
        /// </summary>
        public string Empaquetado { get; set; }
        #endregion

    }
}
