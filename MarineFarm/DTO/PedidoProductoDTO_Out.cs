namespace MarineFarm.DTO
{
    /// <summary>
    /// para generar la salida a detalle de un producto en un pedido
    /// </summary>
    public class PedidoProductoDTO_Out : ProductoDTO_out
    {
        /// <summary>
        /// cantidad solicitada en kg
        /// </summary>
        public double Cantidad { get; set; }
        /// <summary>
        /// si este elemento se encuentra completado
        /// </summary>
        public bool Complete { get; set; } = false;

    }
}
