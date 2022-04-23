namespace MarineFarm.Entitys
{
    /// <summary>
    /// Para almacenar el detalle diario de lo producido en promedio por mes
    /// este es para calcular tiempos de produccion
    /// </summary>
    public class MuestraDiaria
    {
        #region props
        /// <summary>
        /// mes de ano
        /// </summary>
        public int mes { get; set; }
        /// <summary>
        /// ano de estudio
        /// </summary>
        public int ano { get; set; }
        /// <summary>
        /// marisco que se produjo
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// tipo de produccion
        /// </summary>
        public int TipoProduccionid { get; set; }
        /// <summary>
        /// Calibre 
        /// </summary>
        public int Calibreid { get; set; }
        /// <summary>
        /// Empaquetado
        /// </summary>
        public int Empaquetadoid{ get; set; }
        /// <summary>
        /// lo que se ha producido en la totalidad de este mes
        /// </summary>
        public double TotalProducido { get; set; }
        /// <summary>
        /// La Produccion Diaria
        /// </summary>
        public double ProduccionDiaria { get; set; }

        // === nav props

        /// <summary>
        /// nav prop
        /// </summary>
        public Marisco Marisco { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public TipoProduccion TipoProduccion { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Calibre Calibre { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Empaquetado Empaquetado { get; set; }
        #endregion

    }
}
