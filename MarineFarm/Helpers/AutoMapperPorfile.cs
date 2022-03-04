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
            ProductoMap();
            MateriaPrimaMap();
            AlmacenMap();
            HsMateriaPrimaMap();
            ProduccionMap();
            EquipoMap();
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
            CreateMap<GTipoDTO_in, Turnos>()
                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<GTipoDTO_out, Turnos>()
                .ReverseMap();

            CreateMap<CargosDTO_in, Cargos>()
                                .ForMember(x => x.act, opt => opt.MapFrom(y => true));

            CreateMap<CargosDTO_out, Cargos>()
                .ReverseMap();





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


    }
}
