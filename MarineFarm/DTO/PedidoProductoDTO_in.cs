namespace MarineFarm.DTO
{
    /// <summary>
    /// insercion de productos en los pedidos
    /// </summary>
    public class PedidoProductoDTO_in: ProductoDTO_in
    {
        /// <summary>
        /// Cantidad de productos
        /// </summary>
        public double Cantidad { get; set; }
    }
}
