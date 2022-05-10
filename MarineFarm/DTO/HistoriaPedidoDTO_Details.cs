

using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.DTO
{
    /// <summary>
    /// datos que se muestran en el historial de pedidos
    /// </summary>
    class HistorialPedidoDTO_Details:PedidoDTO_out
    {
        #region props
        /// <summary>
        /// Razon por la que eliminaron el pedido
        /// </summary>
        public string? EliminadoRazon { get; set; }
        /// <summary>
        ///  Quien elimino el pedido
        /// </summary>
        public string? EliminadoQuien { get; set; }
        #endregion

        #region  complete

        public async Task Completar(ApplicationDbContext context)
        {
            await Complete(context);

                var aux = await context.PedidosEliminados
                .Include(y=>y.QuienElimino)
                .Where(y=>y.Eliminadoid==this.id)
                .FirstOrDefaultAsync();

                if(aux!=null && aux.Eliminadoid == this.id && aux.QuienEliminoid>0)
                {
                   this.EliminadoQuien=$"{aux.QuienElimino.Nombre} || {aux.QuienElimino.rut}";
                   this.EliminadoRazon=aux.Razon; 
                }
                else
                    this.EliminadoRazon=this.EliminadoQuien=string.Empty;
            }

        }

        #endregion
}  
