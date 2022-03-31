using MarineFarm.Data;
using MarineFarm.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarineFarm.DTO
{
    /// <summary>
    /// Para ingresar un nuevo producto a produccion
    /// </summary>
    public class ProduccionDTO_in
    {

        #region props
        /// <summary>
        /// pivote mariscos producccion
        /// </summary>
        [ModelBinder(BinderType = typeof(TypeBinder<List<PivotProduccionDTO_in>>))]
        public List<PivotProduccionDTO_in> ProduccionIn { get; set; }

        #endregion



        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public ProduccionDTO_in()
        {
            this.ProduccionIn = new();
        }
        /// <summary>
        /// contructor para vista
        /// </summary>
        /// <param name="dto"></param>
        public ProduccionDTO_in(ProduccionDTOView_in dto)
        {
            this.ProduccionIn = new();

            foreach (var usado in dto.usado)
            {
                PivotProduccionDTO_in aux = new()
                {
                    Productos = new(),
                    Mariscoid = usado.mariscoid,
                    CantidadUtilizada = usado.usado
                };

                var filter = dto.pedido.Where(y => y.mariscoid == usado.mariscoid).ToList();
                if(filter != null && filter.Count > 0)
                    foreach (var item in filter)
                    {
                        aux.Productos.Add(new()
                        {
                            Calibreid = item.calibre,
                            TipoProduccionid = item.tipoproduccion,
                            CantProduccida = item.producido,
                            Empaquetadoid = item.empaquetado
                        });

                    }

                this.ProduccionIn.Add(aux);
            }

        }

        #endregion

        #region valid

        /// <summary>
        /// verifica si el valor o valores ingresados son validos
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public async Task<List<Err>> inValid(ApplicationDbContext context)
        {
            List<Err> errores = new();

            try
            {
                foreach (var marisco in this.ProduccionIn)
                {
                    double SUM = 0;


                    var almacen = await context.MateriasPrimas
                       .Include(x => x.Marisco)
                       .Where(x => x.Mariscoid == marisco.Mariscoid)
                       .FirstOrDefaultAsync();

                    if (almacen != null && almacen.id > 0)
                    {

                        if (almacen.Cantidad < marisco.CantidadUtilizada)
                            errores.Add(new(almacen.Marisco.Name, "No Hay Tanta Materia Prima Para Este Producto"));

                        foreach (var item in marisco.Productos)
                            SUM += item.CantProduccida;
                        if (SUM > marisco.CantidadUtilizada)
                            errores.Add(new Err(almacen.Marisco.Name, "La cantidad Producida supera a la utilizada"));
                    }
                    else
                        errores.Add(new("Global", $"No Existe Registros En El Almacen Para Cierto Producto id: {marisco.Mariscoid}"));
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            return errores;
        }


        #endregion


    }
}
