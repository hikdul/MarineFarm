namespace MarineFarm.DTO
{
    /// <summary>
    /// para tener los datalles de un pedido
    /// </summary>
    public class PedidoDTO_out : PedidoDTOS_out
    {
       
        /// <summary>
        /// listado de productos
        /// </summary>
        public List<PedidoProductoDTO_Out> Productos { get; set; }
        
    }
}
