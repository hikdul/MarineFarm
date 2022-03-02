namespace MarineFarm.DTO
{
    /// <summary>
    /// detalles por porducto
    /// </summary>
    public class DatosProduccionProductos_out
    {
        /// <summary>
        /// tipo de produccion al que se refiere
        /// </summary>
        public string TipoProduccion { get; set; }

        /// <summary>
        /// calibre del Tipo de produccion
        /// </summary>
        public string Calibre { get; set; }
        /// <summary>
        /// Empaquetado del producto
        /// </summary>
        public string Empaquetado { get; set; }
        /// <summary>
        /// Cantidad de productos producida
        /// </summary>
        public double CantProduccida { get; set; }
    }
}
