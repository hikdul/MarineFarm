namespace MarineFarm.Entitys
{
    /// <summary>
    /// pivote de productos en cada pedido
    /// </summary>
    public class PedidosProductos
    {
        /// <summary>
        /// pedido 
        /// </summary>
        public int pedidoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Pedido pedido { get; set; }
        /// <summary>
        /// producto
        /// </summary>

        public int Productoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Producto Producto { get; set; }

    }
}
