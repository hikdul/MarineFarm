using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    public class PivotProduccionDTO_in
    {
        /// <summary>
        /// id del marisco en si
        /// </summary>
        public int Mariscoid { get; set; }

        /// <summary>
        /// Cantidad que se gastara en produccion
        /// </summary>
        [Range(0, double.MaxValue)]
        public double CantidadUtilizada { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<PivotProductosProduccionDTO_in>>))]
        public List<PivotProductosProduccionDTO_in> Productos { get; set; }
    }
}
