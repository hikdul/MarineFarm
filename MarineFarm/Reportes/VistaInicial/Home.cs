using AutoMapper;
using MarineFarm.Data;
using MarineFarm.DTO;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.Reportes.VistaInicial
{
    /// <summary>
    /// clase para mostrar los datos de inicio de pantalla
    /// </summary>
    public class Home
    {
        #region props
        public int cantidad { get; set; }
        /// <summary>
        /// mayores cantidades de materia prima
        /// </summary>
        public List<MateriaPrimaDTO_out> MateriaPrima { get; set; }
        /// <summary>
        /// mayor produccion en almacen
        /// </summary>
        public List<PedidoProductoDTO_Out> ProduccionAlmacen { get; set; }
        /// <summary>
        /// mayor produccion del mes
        /// </summary>
        public List<PedidoProductoDTO_Out> MayorProduccionMes { get; set; }
        /// <summary>
        /// total pedido completados este año
        /// </summary>
        public List<pedidoAnoHome> PedidosAno { get; set; }

        #endregion

        #region ctor

        /// <summary>
        /// ctor
        /// </summary>
        public Home( int cantidad = 10)
        {
            this.cantidad = 10;
            this.MateriaPrima = new();
            this.MayorProduccionMes = new();
            this.ProduccionAlmacen = new();
            this.PedidosAno = new();

        }

        #endregion


        #region llenar datos
        public async Task<Home> Up(ApplicationDbContext context,IMapper mapper, int cantidad = 10 )
        {
            Home home = new(cantidad);
            try
            {
                //empesamos con materias prima
                var mp = await context
                    .MateriasPrimas
                    .Include(y => y.Marisco)
                    .Where(y => y.Cantidad > 0)
                    .OrderBy(y => y.Cantidad)
                    .Take(home.cantidad)
                    .ToListAsync();
                if (mp != null && mp.Count > 0)
                    home.MateriaPrima = mapper.Map<List<MateriaPrimaDTO_out>>(mp);

                // almacen
                var a = await context
                    .Almacen
                    .Include(y => y.Producto).ThenInclude(y => y.Marisco)
                    .Include(y => y.Producto).ThenInclude(y => y.TipoProduccion)
                    .Include(y => y.Producto).ThenInclude(y => y.Calibre)
                    .Include(y => y.Producto).ThenInclude(y => y.Empaquetado)
                    .Where(y => y.Cantidad > 0 )
                    .OrderBy(y => y.Cantidad)
                    .Take(home.cantidad)
                    .ToListAsync();
                if (a != null && a.Count > 0)
                    home.ProduccionAlmacen = mapper.Map<List<PedidoProductoDTO_Out>>(a);
                //produccion mes
                var date = DateTime.Now;
                var pm = await context
                    .Produccion
                    .Where(y => y.Fecha.Month == date.Month && y.Fecha.Year == date.Year)
                    .Select(y => y.ProductoProduccion.OrderBy(y => y.CantidadProducida).Take(home.cantidad)).ToListAsync();


                // pedidos completados ano

            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return home;
        }

        #endregion

    }



    /// <summary>
    /// individual de los productos mes
    /// </summary>

    public class pedidoAnoHome
    {
        /// <summary>
        /// mes al que corresponde
        /// </summary>
        public int mes { get; set; }
        /// <summary>
        /// Cantidad completado
        /// </summary>
        public int cantidadCompletada { get; set; }
        /// <summary>
        /// cantidad de pedidos solicitadas durante el mes
        /// </summary>
        public int cantidadSolicitada { get; set; }
        /// <summary>
        ///  contidad de pedidos cancelada durante el mes
        /// </summary>
        public int cantidadCancelada { get; set; }
    }

}
