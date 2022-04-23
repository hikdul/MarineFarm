using AutoMapper;
using MarineFarm.Auth;
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
        /// ctor
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
            MuestraDiariaMap();
            UsMap();
            UsClienteMap();
            ConfigurationMap();
        }

        #region mapeo Generica elementos de interface ITipo
        /// <summary>
        /// solo es un mapeo generico
        /// </summary>
        /// <typeparam name="T"></typeparam>
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
        #endregion

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

            CreateMap<PedidoDTO_in, Pedido>()
                .ForMember(ee => ee.act, opt => opt.MapFrom(y => true))
                .ForMember(ee => ee.FechaEntrega, opt => opt.Ignore())
                .ForMember(ee => ee.FechaSolicitud, opt => opt.MapFrom(y => DateTime.Now))
                .ForMember(ee => ee.PedidoProductos, opt => opt.Ignore());
                //.ForMember(ee => ee.PedidoProductos, opt => opt.MapFrom(PedidoProductoMap));

           
        }


        private List<PedidosProductos> PedidoProductoMap(PedidoDTO_in dto, Pedido ent)
        {
            List<PedidosProductos> list = new();
            if (dto.Productos == null || dto.Productos.Count < 1)
                return list;

            foreach (var item in dto.Productos)
            {
                if(item.Cantidad > 0)
                    list.Add(new()
                    {
                        Cantidad = item.Cantidad,
                        Producto = new()
                        {
                            TipoProduccionid = item.TipoProduccionid,
                            Calibreid = item.Calibreid,
                            Mariscoid = item.Mariscoid,
                            Empaquetadoid = item.Empaquetadoid,
                            act = true,
                        }
                    });
            }

            return list;
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

        #region usuarios Map

        private void UsMap()
        {
            CreateMap<UsuarioDTO_in, Usuario>()
                .ForMember(y => y.Rol, o => o.MapFrom(RolPublico))
                .ForMember(y => y.Userid, o => o.Ignore());
            CreateMap<Usuario, UsuarioDTO_out>();
        }
        private void UsClienteMap()
        {
            CreateMap<UsuarioClienteDTO_in, Usuario>()
                 .ForMember(y => y.Rol, o => o.MapFrom(RolPublico))
                .ForMember(y => y.Userid, o => o.Ignore())
                .ForMember(y => y.act, o => o.MapFrom(x => true));

            CreateMap<UsuarioCliente, UsuarioClienteDTO_out>()
                .ForMember(y => y.Nombre, o => o.MapFrom(nombreCliente))
                .ForMember(y => y.Email, o => o.MapFrom(emailCliente))
                .ForMember(y => y.Rol, o => o.MapFrom(rolCliente))
                .ForMember(y => y.rut, o => o.MapFrom(rutCliente))
                .ForMember(y => y.Telefono, o => o.MapFrom(telefonoCliente))
                .ForMember(y => y.Cliente, o => o.MapFrom(ClienteCliente))
                .ForMember(y => y.RUT, o => o.MapFrom(ClienteClienteRUT));
        }


        private string ClienteClienteRUT(UsuarioCliente ent, UsuarioClienteDTO_out dto)
        {

            if (ent.Cliente == null || ent.Cliente.id < 1 || String.IsNullOrEmpty(ent.Cliente.RUT))
                return String.Empty;
            return ent.Cliente.RUT;
        }
        private string ClienteCliente(UsuarioCliente ent, UsuarioClienteDTO_out dto)
        {

            if (ent.Cliente == null || ent.Cliente.id < 1 || String.IsNullOrEmpty(ent.Cliente.Name))
                return String.Empty;
            return ent.Cliente.Name;
        }
        private string rutCliente(UsuarioCliente ent, UsuarioClienteDTO_out dto)
        {
            if (ent.Usuario == null || ent.Usuario.id < 1 || String.IsNullOrEmpty(ent.Usuario.rut))
                return String.Empty;
            return ent.Usuario.rut;
        }

        private string telefonoCliente(UsuarioCliente ent, UsuarioClienteDTO_out dto)
        {
            if (ent.Usuario == null || ent.Usuario.id < 1 || String.IsNullOrEmpty(ent.Usuario.Telefono))
                return String.Empty;
            return ent.Usuario.Telefono;
        }

        private string rolCliente(UsuarioCliente ent, UsuarioClienteDTO_out dto)
        {
            if (ent.Usuario == null || ent.Usuario.id < 1 || String.IsNullOrEmpty(ent.Usuario.Rol))
                return String.Empty;
            return ent.Usuario.Rol;
        }

        private string nombreCliente(UsuarioCliente ent, UsuarioClienteDTO_out dto)
        {
            if (ent.Usuario == null || ent.Usuario.id < 1 || String.IsNullOrEmpty(ent.Usuario.Nombre))
                return String.Empty;
            return ent.Usuario.Nombre;
        }

        private string emailCliente(UsuarioCliente ent, UsuarioClienteDTO_out dto)
        {
            if (ent.Usuario == null || ent.Usuario.id < 1 || String.IsNullOrEmpty(ent.Usuario.Email))
                return String.Empty;
            return ent.Usuario.Email;
        }

        private string RolPublico(UsuarioDTO_in dto, Usuario ent)
        {
            if (dto == null || dto.LvlRol < 0 || dto.LvlRol > 3)
                return "";
            return Usuario.GetRol(dto.LvlRol);
        }


        #endregion

        #region Muestra Diaria Map

        private void MuestraDiariaMap()
        {
            CreateMap<MuestraDiaria, CalculoProduccionDTO_out>()
               .ForMember(y => y.Marisco, o => o.MapFrom(CalculoMarisco))
               .ForMember(y => y.TipoProduccion, o => o.MapFrom(CalculoTipoProduccion))
               .ForMember(y => y.Calibre, o => o.MapFrom(CalculoCalibre))
               .ForMember(y => y.Empaquetado, o => o.MapFrom(CalculoEmpaquetado))
               .ForMember(y => y.dias, o => o.MapFrom(x => 0))
               .ForMember(y => y.PosibleEntrega, o => o.Ignore());

        }


        private string CalculoMarisco(MuestraDiaria ent, CalculoProduccionDTO_out dto)
        {
            if (ent == null || ent.Marisco == null || ent.Marisco.Name == null)
                return " -- ";
            return ent.Marisco.Name;
        }

        private string CalculoTipoProduccion(MuestraDiaria ent, CalculoProduccionDTO_out dto)
        {
            if (ent == null || ent.TipoProduccion == null || ent.TipoProduccion.Name == null)
                return " -- ";
            return ent.TipoProduccion.Name;
        }

        private string CalculoCalibre(MuestraDiaria ent, CalculoProduccionDTO_out dto)
        {
            if (ent == null || ent.Calibre == null || ent.Calibre.Name == null)
                return " -- ";
            return ent.Calibre.Name;
        }

        private string CalculoEmpaquetado(MuestraDiaria ent, CalculoProduccionDTO_out dto)
        {
            if (ent == null || ent.Empaquetado == null || ent.Empaquetado.Name == null)
                return " -- ";
            return ent.Empaquetado.Name;
        }
        #endregion

        #region config map
        
        private void ConfigurationMap()
        {
            CreateMap<Configuraciones, ConfigurcionDTO>().ReverseMap();
        }
        #endregion
    }
}
