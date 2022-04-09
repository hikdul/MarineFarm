using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MarineFarm.DTO
{
    /// <summary>
    /// Para ingresar un nuevo pedido
    /// </summary>
    public class PedidoDTO_in
    {

        /// <summary>
        /// cliente al que va el pedido
        /// </summary>
        public int Clienteid { get; set; }
        /// <summary>
        /// Productos
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<PedidoProductoDTO_in>>))]
        public List<PedidoProductoDTO_in> Productos { get; set; }
        /// <summary>
        /// me entrega la fecha en que se iniciara la produccion.
        /// por defecto es la fecha actual
        /// </summary>
        public DateTime fecha { get; set; } = DateTime.Now;

    }
}
