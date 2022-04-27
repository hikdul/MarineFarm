using MarineFarm.Auth;
using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// para almacenar los datos de un pedido
    /// </summary>
    public class Pedido : Iid
    {
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Cliente al que pertenece el pedido
        /// </summary>
        public int Clienteid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// persona que solicito el pedido
        /// </summary>
        public int Solicitanteid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Usuario Solicitante { get; set; }
        /// <summary>
        /// fecha en que se genero la solicitud
        /// </summary>
        public DateTime FechaSolicitud { get; set; }
        /// <summary>
        /// fecha en que se realizo la entrega del producto
        /// </summary>
        public DateTime? FechaEntrega { get; set; }
        /// <summary>
        /// fecha en que el sistema cree se entregara el producto
        /// </summary>
        public DateTime FechaEntregaPosible { get; set; }
        /// <summary>
        /// listado de productos
        /// </summary>
        public List<PedidosProductos> PedidoProductos { get; set; }
        /// <summary>
        /// si el elemento se encuentra activo o no
        /// </summary>
        public bool act { get; set; }
        /// <summary>
        /// para verificar el estado del pedido
        /// 0 => solicitado 
        /// 1 => completado
        /// 2 => cancelado
        /// </summary>
        public int estado { get; set; } = 0;
    }
}
