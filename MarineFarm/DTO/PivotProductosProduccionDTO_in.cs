namespace MarineFarm.DTO
{
    /// <summary>
    /// para ingresar el productor pertinente
    /// </summary>
    public class PivotProductosProduccionDTO_in
    {
        /// <summary>
        /// tipo de produccion al que se refiere
        /// </summary>
        public int TipoProduccionid { get; set; }

        /// <summary>
        /// calibre del Tipo de produccion
        /// </summary>
        public int Calibreid { get; set; }
        /// <summary>
        /// Empaquetado del producto
        /// </summary>
        public int Empaquetadoid { get; set; }
        /// <summary>
        /// Cantidad de productos producida
        /// </summary>
        public double CantProduccida { get; set; }
    }
}
