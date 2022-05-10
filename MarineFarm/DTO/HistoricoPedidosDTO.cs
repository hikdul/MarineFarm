using MarineFarm.Auth;
using MarineFarm.Entitys;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para mostar los datos de un pedido en su historico
    /// </summary>
    public class HistoricoPedidoDTO
    {

        /// <summary>
        ///  id del pedido
        /// </summary>
        public int id { get; set; }
        /// <summary>
        ///  Nombre del clente que tiene este pedido
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// rut del cliente
        /// </summary>
        public string Rut { get; set; }
        /// <summary>
        /// nombre de quien lo solicito
        /// </summary>
        public string SolicitanteNombre { get; set; }
        /// <summary>
        /// Rut de quien lo solicito
        /// </summary>
        public string SolicitanteRut { get; set; }
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
        /// si el elemento se encuentra activo o no
        /// </summary>
        public bool act { get; set; }
        /// <summary>
        /// para verificar el estado del pedido
        /// 0 => Solicitado 
        /// 1 => Completado
        /// 2 => Cancelado
        /// </summary>
        public int estado { get; set; } = 0;

    }
}