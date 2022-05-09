namespace MarineFarm.Reportes.ReportePedidosCompletados
{
/// <summary>
/// datos que se mostraran por cada pais
/// </summary>
    public class PorPais
    {

        /// <summary>
        /// numero de pedidos completados
        /// </summary>
        public int PedidosCompletados { get; set; }
        /// <summary>
        /// numero de pedido cancelados
        /// </summary>
        public int PedidosCancelados { get; set; }
        /// <summary>
        /// pedidos que aun estan a la espera de respuesta
        /// </summary>
        public int PedidosNoCompletados { get; set; }

        //ahora vienen los datos por cada marisco que deba de tener
        /// <summary>
        /// cantidad de mariscos pedidos
        /// </summary>
        public List<MariscoPedidos> Maricos { get; set; }

    }
}
