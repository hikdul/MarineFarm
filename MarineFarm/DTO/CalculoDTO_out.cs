namespace MarineFarm.DTO
{
    /// <summary>
    /// datos de salida de los calculos
    /// </summary>
    public class CalculoDTO_out
    {
        /// <summary>
        /// fecha de posible entrega del pedido
        /// </summary>
        public DateTime EntregaPedido { get; set; }
        /// <summary>
        /// calculo por cada elemeneto del pedido
        /// </summary>
        public List<CalculoProduccionDTO_out> CalculoPorElemento { get; set; }
    }
}
