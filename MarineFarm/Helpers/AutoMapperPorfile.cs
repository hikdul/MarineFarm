using AutoMapper;
using MarineFarm.DTO;
using MarineFarm.Entitys;

namespace MarineFarm.Helpers
{
    /// <summary>
    /// Para almacenar todas las configuraciones de automapper
    /// </summary>
    public class AutoMapperPorfile: Profile
    {
        /// <summary>
        /// run
        /// </summary>
        public AutoMapperPorfile()
        {
           
            CustamMapITipe<Empaquetado>();
            CustamMapITipe<Marisco>();
            CustamMapITipe<Calibre>();
            CustamMapITipe<TipoProduccion>();
            CustamMapITipe<Turnos>();
            ProductoMap();
            MateriaPrimaMap();
            AlmacenMap();
            HsMateriaPrimaMap();
            ProduccionMap();
            EquipoMap();
            PedidosMap();
            ClienteMap();
        }

        private void CustamMapITipe<T>() where T : class, Iid
        {
            CreateMap<GTipoDTO_in, T>()
                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<GTipoDTO_out, T>()
                .ReverseMap();
            CreateMap<T, GTipoDTO_edit>();
            CreateMap<GTipoDTO_edit, T>()
                .ForMember(e => e.act, opt => opt.MapFrom(ee => true));

        }

        #region equipo

        private void EquipoMap()
        {
            CreateMap<CargosDTO_in, Cargos>()
                                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<CargosDTO_out, Cargos>()
                .ReverseMap();

            CreateMap<Cargos, CargoDTO_edit>();
            CreateMap< CargoDTO_edit, Cargos>()
                .ForMember(x => x.act, opt => opt.MapFrom(ee => true));
        }



        #endregion

        #region producto

        private void ProductoMap()
        {
            CreateMap<ProductoDTO_in, Producto>()
                .ForMember(x => x.Calibre, opt => opt.Ignore())
                .ForMember(x => x.TipoProduccion, opt => opt.Ignore())
                .ForMember(x => x.Marisco, opt => opt.Ignore())
                .ForMember(x => x.Empaquetado, opt => opt.Ignore())
                .ForMember(x => x.act, opt => opt.MapFrom(x => true));

            CreateMap<Producto, ProductoDTO_Details>()
                .ReverseMap();

            CreateMap<Producto, ProductoDTO_out>()
                .ForMember(x => x.Calibre, opt => opt.MapFrom(x => x.Calibre.Name))
                .ForMember(x => x.TipoProduccion, opt => opt.MapFrom(x => x.TipoProduccion.Name))
                .ForMember(x => x.Marisco, opt => opt.MapFrom(x => x.Marisco.Name))
                .ForMember(x => x.Empaquetado, opt => opt.MapFrom(x => x.Empaquetado.Name));



        }

        #endregion

        #region MateriaPrima

        private void MateriaPrimaMap()
        {
            CreateMap<MateriaPrima, MateriaPrimaDTO>().ReverseMap();

            CreateMap<MateriaPrimaDTO_in, MateriaPrima>()
                .ForMember(x => x.Marisco, opt => opt.Ignore());

            CreateMap<MateriaPrima, MateriaPrimaDTO_out>()
                .ForMember(x => x.Marisco, opt => opt.MapFrom(MateriaPrimaOnlyText));

        }

        private string MateriaPrimaOnlyText(MateriaPrima ent, MateriaPrimaDTO_out dto)
        {
            return ent.Marisco.Name;
        }

        #endregion

        #region Almacen

        private void AlmacenMap()
        {

            CreateMap<Almacen, AlmacenDTO>().ReverseMap();
            CreateMap<Almacen, AlmacenDTO_out>()
                .ForMember(x => x.Marisco, opt => opt.MapFrom(MariscoOutAlmacen))
                .ForMember(x => x.Calibre, opt => opt.MapFrom(CalibreOutAlmacen))
                .ForMember(x => x.TipoProduccion, opt => opt.MapFrom(TipoProdOutAlmacen))
                .ForMember(x => x.Empaquetado, opt => opt.MapFrom(EmpaquetadoOutAlmacen));



        }

        private string CalibreOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.Calibre.Name;
        }

        private string MariscoOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.Marisco.Name;
        }

        private string TipoProdOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.TipoProduccion.Name;
        }

        private string EmpaquetadoOutAlmacen(Almacen ent, AlmacenDTO_out dto)
        {
            return ent.Producto.Empaquetado.Name;
        }


        #endregion

        #region Historial Materia Prima

        private void HsMateriaPrimaMap()
        {

            CreateMap<HistorialMateriaPrima, HistorialMateriaPrimaDTO_out>()
                .ForMember(x => x.Marisco, opt => opt.MapFrom(MariscoEnHsMP))
                .ForMember(x => x.NombreQuienRegistro, opt => opt.MapFrom(NombreEnHSMP))
                .ForMember(x => x.rutQuienRegistro, opt => opt.MapFrom(RutEnHSMP));
        }

        private string MariscoEnHsMP(HistorialMateriaPrima ent, HistorialMateriaPrimaDTO_out dto)
        {
            return ent == null ? "" : ent.Marisco.Name;
        }

        private string NombreEnHSMP(HistorialMateriaPrima ent, HistorialMateriaPrimaDTO_out dto)
        {
            return ent == null ? "" : ent.Usuario.Nombre;
        }
        private string RutEnHSMP(HistorialMateriaPrima ent, HistorialMateriaPrimaDTO_out dto)
        {
            return ent == null ? "" : ent.Usuario.rut;
        }

        #endregion

        #region Produccion

        private void ProduccionMap()
        {
            CreateMap<Produccion, ProduccionDTO_out>()
                .ForMember(x => x.SupervEmail, opt => opt.MapFrom(EmailSP))
                .ForMember(x => x.SupervName, opt => opt.MapFrom(NameSP))
                .ForMember(x => x.productos, opt => opt.MapFrom(CompleteProduccion));
        }

        /// <summary>
        /// para generar el total de lo faltante en produccion
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        private List<DatosProduccion_out> CompleteProduccion(Produccion ent, ProduccionDTO_out dto)
        {
            List<DatosProduccion_out> ret = new();

            if (ent.MariscosProduccion == null)
                return ret;

            foreach (var item in ent.MariscosProduccion)
            {
                DatosProduccion_out band = new();

                band.CantUsada = item.CantidadUtilizada;
                band.Marisco = item.Marisco.Name;
                band.Productos = new();
                if (ent.ProductoProduccion != null)
                    foreach (var prod in ent.ProductoProduccion)
                    {
                        if (prod.Producto.Mariscoid == item.Mariscoid)
                        {
                            band.Productos.Add(new()
                            {
                                Calibre = prod.Producto.Calibre.Name,
                                Empaquetado = prod.Producto.Empaquetado.Name,
                                TipoProduccion = prod.Producto.TipoProduccion.Name,
                                CantProduccida = prod.CantidadProducida,
                            });
                        }
                    }

                ret.Add(band);

            }

            return ret;

        }

        /// <summary>
        /// obtiene el email
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        private string EmailSP(Produccion ent, ProduccionDTO_out dto)
        {
            return ent.Superv.Email;
        }
        /// <summary>
        /// obtiene el nombre
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        private string NameSP(Produccion ent, ProduccionDTO_out dto)
        {
            return ent.Superv.Nombre;
        }

        #endregion

        #region pedido

        private void PedidosMap()
        {
            CreateMap<Pedido, PedidoDTOS_out>()
                .ForMember(ee => ee.Cliente, opt => opt.MapFrom(PedidoNombreCliente))
                .ForMember(ee => ee.Solicitante, opt => opt.MapFrom(PedidoNombreSolicitante));

            CreateMap<Pedido, PedidoDTO_out>()
                .ForMember(ee => ee.Cliente, opt => opt.MapFrom(PedidoNombreCliente))
                .ForMember(ee => ee.Solicitante, opt => opt.MapFrom(PedidoNombreSolicitante))
                .ForMember(ee => ee.Productos, opt => opt.MapFrom(ProductosEnPedido));

        }


        private List<PedidoProductoDTO_Out> ProductosEnPedido(Pedido ent, PedidoDTO_out dto)
        {
            List<PedidoProductoDTO_Out> list = new();
            if (ent == null || ent.PedidoProductos.Count < 1)
                return list;

            foreach (var item in ent.PedidoProductos)
                list.Add(new()
                {
                    id = item.Productoid,
                    act = item.Producto.act,
                    Calibre = item.Producto.Calibre.Name,
                    Empaquetado = item.Producto.Empaquetado.Name,
                    Marisco = item.Producto.Marisco.Name,
                    TipoProduccion = item.Producto.TipoProduccion.Name,
                    Cantidad = item.Cantidad
                });

            return list;
        }

        private string PedidoNombreCliente(Pedido ent, PedidoDTOS_out dto)
        {
            if (ent == null ||  ent.Cliente == null || ent.Cliente.Name == null)
                return "";

            return ent.Cliente.Name;

        }

        private string PedidoNombreSolicitante(Pedido ent, PedidoDTOS_out dto)
        {
            if (ent == null || ent.Solicitante == null || ent.Solicitante.Nombre == null)
                return "";

            return ent.Solicitante.Nombre;
        }

        #endregion

        #region Cliente

        private void ClienteMap()
        {
            CreateMap<ClienteDTO_in, Cliente>()
                .ForMember(ee => ee.act, opt => opt.MapFrom(x => true));

            CreateMap<Cliente, ClienteDTO_out>().ReverseMap();

        }

        #endregion
    }
}
