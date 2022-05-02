using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.Reportes.TotalProduccion
{
    /// <summary>
    /// datos que se envian para generar un reporte
    /// </summary>
    public class AllReportDTO_in
    {
        #region props 
        /// <summary>
        /// inicio del periodo
        /// </summary>
        public DateTime Inicio { get; set; }
        /// <summary>
        /// fin del periodo
        /// </summary>
        public DateTime Fin { get; set; }
        /// <summary>
        /// marisca que se desea buscar. si es menor que 1 se envian todos los datos validos
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> Mariscoid { get; set; }


        #endregion

        #region validate
        /// <summary>
        ///  verifica e indica si la clase es valida para generar el reporte
        /// </summary>

        public bool validate()
        {
            return Inicio <= Fin && Mariscoid.Count > 0;
        }
        
        #endregion
    }
}
