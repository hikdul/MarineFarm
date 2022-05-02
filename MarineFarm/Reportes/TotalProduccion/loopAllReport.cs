using MarineFarm.Entitys;

namespace MarineFarm.Reportes.TotalProduccion
{
    /// <summary>
    /// contiene los elementos y sus totales pon periodo
    /// </summary>
    public class loopAllReport
    {
        #region props
        /// <summary>
        /// Total Producido
        /// </summary>
        public TipoProduccion TipoProd { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        public Calibre Calibre { get; set; }
        /// <summary>
        /// Total producido de este elemento
        /// </summary>
        public double TotalProducido { get; set; }
        #endregion

        #region ctor
        /// <summary>
        /// ctor para guardar los datos
        /// </summary>
        /// <param name="tp"></param>
        /// <param name="c"></param>
        /// <param name="prod"></param>
        public loopAllReport(TipoProduccion tp, Calibre c, double prod)
        {
            this.TipoProd = tp;
            this.Calibre = c;
            this.TotalProducido = prod;
        }
        #endregion

    }
}
