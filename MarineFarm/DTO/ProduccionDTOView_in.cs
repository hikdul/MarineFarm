using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para agregar una nueva produccion desde las vistas
    /// </summary>
    public class ProduccionDTOView_in
    {

        /// <summary>
        /// datos de elementos por pedido
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<__p>>))]
        public List<__p> pedido { get; set; }
        /// <summary>
        /// cantidades usadas por marisca
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<__u>>))]
        public List<__u> usado { get; set; }
    }
    /// <summary>
    /// elementos por pedido
    /// </summary>
    public class __p
    {
        /// <summary>
        /// id del marisco
        /// </summary>
        public int mariscoid { get; set; }
        /// <summary>
        /// id del tipo de produccion
        /// </summary>
         public int tipoproduccion{ get; set; }
        /// <summary>
        /// id del calibre
        /// </summary>
         public int calibre       { get; set; }
        /// <summary>
        /// id del empaquetado
        /// </summary>
        public int empaquetado { get; set; }
        /// <summary>
        /// cantidad producida
        /// </summary>
         public double producido { get; set; }
    }
         /// <summary>
         /// usados por mariscos
         /// </summary>
    public class __u
    {
        /// <summary>
        /// mariscos id
        /// </summary>
        public int mariscoid { get; set; }
        /// <summary>
        /// cantidades usadas
        /// </summary>
        public double usado  { get; set; }
          
    }
}
