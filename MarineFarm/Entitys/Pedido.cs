using MarineFarm.Auth;
using MarineFarm.Data;
using MarineFarm.Helpers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// para almacenar los datos de un pedido
    /// </summary>
    public class Pedido : Iid
    {
        #region props
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Cliente al que pertenece el pedido
        /// </summary>
        public int Clienteid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// persona que solicito el pedido
        /// </summary>
        public int Solicitanteid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Usuario Solicitante { get; set; }
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
        /// listado de productos
        /// </summary>
        public List<PedidosProductos> PedidoProductos { get; set; }
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
        #endregion


        #region ctor
        
        /// <summary>
        /// empty
        /// </summary>
        public Pedido()
        {

        }
        /// <summary>
        /// copy ctor
        /// </summary>
        public Pedido(Pedido p)
        {
            this.id = p.id;
            this.Clienteid = p.Clienteid;
            this.Cliente = p.Cliente;
            this.estado = p.estado;
            this.FechaEntrega = p.FechaEntrega;
            this.FechaEntregaPosible = p.FechaEntregaPosible;
            this.FechaSolicitud = p.FechaSolicitud;
            this.Solicitante = p.Solicitante;
            this.Solicitanteid = p.Solicitanteid;
            this.PedidoProductos = p.PedidoProductos;
                
        }

        #endregion


        #region completar pedido
        /// <summary>
        /// para que me reste del almacen lo que se uso en este pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task CompletePedido(int id, ApplicationDbContext context)
        {
            try
            {
                if (id < 1)
                    return;
                var ent = await context
                    .Pedidos
                    .Include(x=>x.PedidoProductos).ThenInclude(x=>x.Producto)
                    .Where(x => x.id == id)
                    .FirstOrDefaultAsync();

                if (ent == null || ent.id < 1)
                    return;

                foreach (var prod in ent.PedidoProductos)
                {
                    
                    var almacen = await context.Almacen
                        .Where(y => y.Productoid == prod.Productoid)
                        .FirstOrDefaultAsync();

                    if (almacen!=null||almacen.id<0)
                    {
                        almacen.Cantidad = almacen.Cantidad - prod.Cantidad<0? 0 : almacen.Cantidad - prod.Cantidad;
                        await context.SaveChangesAsync();
                        
                    }
                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }
        #endregion
    }
}
