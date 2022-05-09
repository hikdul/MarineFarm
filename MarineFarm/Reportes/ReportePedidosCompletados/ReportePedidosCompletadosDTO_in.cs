namespace MarineFarm.Reportes.ReportePedidosCompletados
{
    /// <summary>
    /// esta clase es para enviar los datos para generar el reporte
    /// </summary>
    public class ReportePedidosCompletadosDTO_in
    {
        #region props
        /// <summary>
        /// Inicio del periodo del reporte
        /// </summary>
        public DateTime Inicio { get; set; }
        /// <summary>
        /// Fin del periodo del reporte
        /// </summary>
        public DateTime Fin { get; set; }
        /// <summary>
        /// nombre de paises para los que se desea hacer el reporte
        /// en caso de que venga vacio el reporte se genera para todos los paises
        /// </summary>
        public List<string>? Paises { get; set; }
        #endregion


        #region validate
        /// <summary>
        /// para validar si los datos ingresados son validos
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return this.Inicio <= this.Fin;
        }

        
        #endregion

    }
}
