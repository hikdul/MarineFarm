namespace MarineFarm.Reportes.ReportePedidosCompletados
{
    /// <summary>
    /// son los datos del reporte en si
    /// </summary>
    public class ReportePedidosCompletados
    {
        #region props
        /// <summary>
        /// fecha de generado
        /// </summary>
        public DateTime fechaGenerado { get; set; }
        /// <summary>
        /// Inicio del periodo de solicitud
        /// </summary>
        public DateTime Inicio { get; set; }
        /// <summary>
        /// fin del pediodo
        /// </summary>
        public DateTime Fin { get; set; }


        #endregion
    }
}
