using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.DTO
{
    public class EquipoDTO_in_View
    {
        /// <summary>
        /// turno que se va a crear
        /// </summary>
        public GTipoDTO_in turno { get; set; }
        /// <summary>
        /// cargos y cantidades cubiertas
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<__inV>>))]
        public List<__inV> cargos { get; set; }
    }


    public class __inV
    {
        public string CargoName { get; set; }
        /// <summary>
        /// id del carga
        /// </summary>
        public int Cargoid { get; set; }
        /// <summary>
        /// cantida de empleados en este cargo
        /// </summary>
        public int CantCubierta { get; set; }
        /// <summary>
        /// Costo por operario
        /// </summary>
        public double CostoOperario { get; set; }
    }
}
