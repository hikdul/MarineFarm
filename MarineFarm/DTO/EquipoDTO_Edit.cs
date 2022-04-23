using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para editar los equipos que esten actualmente en ejecucion
    /// </summary>
    public class EquipoDTO_Edit
    {
        /// <summary>
        /// turno o datos en base a los cuales se genera la edicion 
        /// </summary>
        public GTipoDTO_edit turno { get; set; }
        /// <summary>
        /// cargos y cantidades en los cuales se modifica los datos
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<__in>>))]
        public List<__in> cargos { get; set; }
    }

}
