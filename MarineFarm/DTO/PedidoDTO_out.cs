using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para tener los datalles de un pedido
    /// </summary>
    public class PedidoDTO_out : PedidoDTOS_out
    {
        #region props
        /// <summary>
        /// listado de productos
        /// </summary>
        public List<PedidoProductoDTO_Out> Productos { get; set; }

        /// <summary>
        /// si el pedido esta completo o no
        /// </summary>
        public bool Completado { get; set; } = false;
        #endregion

        #region calcular pedido completado

        /// <summary>
        /// verifica y llena el complemento que indica si un pedido esta completo o no
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Complete(ApplicationDbContext context)
        {
            this.Completado = false;

            if (this.Productos == null || this.Productos.Count < 1)
                return;
            
            bool auxComplete = true;

            foreach (var item in this.Productos)
            {
                var auxAlmacen = await context.Almacen
                    .Where(y => y.Productoid == item.id)
                    .FirstOrDefaultAsync();

                if (auxAlmacen == null || auxAlmacen.Cantidad < item.Cantidad)
                {
                    auxComplete = false;
                    item.Complete = false;
                }
                else
                    item.Complete = true;
                
            }
            this.Completado = auxComplete;

        }

        
        #endregion

    }
}
