namespace MarineFarm.DTOs
{
    /// <summary>
    /// entrega de calculo de individual
    /// </summary>
    public class CalcularFechaDTO_out
    {
        #region props
        /// <summary>
        /// Cantidad de dias de produccion
        /// </summary>
        public int NumeroDias { get; set; }
        /// <summary>
        /// Numero de dias total
        /// </summary>
        public int NumeroDiasRest { get; set; }
        /// <summary>
        /// posible fecha en entrega
        /// </summary>
        public DateTime PosibleFechaEntrega { get; set; }
        #endregion


        #region ctor

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="numDias"></param>
        /// <param name="NumerosDiasRest"></param>
        /// <param name="date"></param>
        public CalcularFechaDTO_out(int numDias, int NumerosDiasRest, DateTime date)
        {
            this.NumeroDias = numDias;
            this.NumeroDiasRest = NumeroDiasRest;
            this.PosibleFechaEntrega = date;
        }


        #endregion

    }
}
