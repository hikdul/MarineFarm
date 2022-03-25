namespace MarineFarm.DTO
{
    /// <summary>
    /// datos del producto sin mucho detalle
    /// </summary>
    public class PedidoDTOS_out
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// si el elemento se encuentra activo o no
        /// </summary>
        public bool act { get; set; }
        /// <summary>
        /// Cliente al que pertenece el pedido
        /// </summary>
        public int Clienteid { get; set; }
        /// <summary>
        /// Nombre Cliente
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// Nombre Solicitante
        /// </summary>
        public string Solicitante { get; set; }
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
    }
}
