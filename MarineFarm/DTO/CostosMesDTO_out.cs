namespace MarineFarm.DTO
{ 
    /// <summary>
    /// para mostrar elementos obtenidos y entregarlos fuera de la app
    /// </summary>
    public class CostosMesDTO_out
    {

        #region props


        /// <summary>
        /// numero de operadores promedio por mes
        /// </summary>

        // === Calculo operadores
        // === === === === === ===


        public double NumOperadores { get; set; }
        /// <summary>
        /// porcentaje de operadores cubiertos
        /// </summary>
        public double PorcentajeOperadoresCubiertos { get; set; }
        /// <summary>
        /// costo promedio de productos por dia
        /// </summary>
        public double CostoPromedioEquipoPorDia { get; set; }

        // === Calculo Producto
        // === === === === === ===

        /// <summary>
        /// Cantidad promedio de productos por dia
        /// </summary>
        public double KgProductoPromedioPorDia { get; set; }

        // === Identificadores
        // === === === === ===


        /// <summary>
        /// año de estudio
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Mes del estudio
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// equipo al que se le sacan los calculos
        /// </summary>
        
        public string Equipo { get; set; }
        /// <summary>
        /// Marisco
        /// </summary>
        
        public string Marisco { get; set; }
        /// <summary>
        /// Calibre
        /// </summary>
        
        public string Calibre { get; set; }
        /// <summary>
        /// Tipo de produccion
        /// </summary>
        public string TipoProduccion { get; set; }
      


        #endregion
    }
}
