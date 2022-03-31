using MarineFarm.Auth;
using MarineFarm.Data;
using MarineFarm.DTO;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    public class Produccion
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// fecha en que fue realizado la produccion
        /// </summary>
        public DateTime Fecha { get; set; } = DateTime.Now;
        /// <summary>
        /// quien esta a cargo de la produccion
        /// </summary>
        public int Supervid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Usuario Superv { get; set; }
        /// <summary>
        /// pivote mariscos producccion
        /// </summary>
        public List<PMariscoProduccion> MariscosProduccion { get; set; }
        /// <summary>
        /// Pivote productos en produccion
        /// </summary>
        public List<PProductoProduccion> ProductoProduccion { get; set; }
        #endregion


        #region mapeo desde Dto_in

        /// <summary>
        /// mapper
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userid"></param>
        /// <param name="context"></param>
        public static async Task<Produccion> Up(ProduccionDTO_in dto, int userid, ApplicationDbContext context)
        {
            try
            {
                var resp = new Produccion();
                resp.Fecha = DateTime.Now;
                resp.Supervid = userid;
                resp.MariscosProduccion = new();
                resp.ProductoProduccion = new();

                foreach (var marisco in dto.ProduccionIn)
                    if (marisco.CantidadUtilizada > 0)
                    {
                        resp.MariscosProduccion.Add(new()
                        {
                            CantidadUtilizada = marisco.CantidadUtilizada,
                            Mariscoid = marisco.Mariscoid,
                        });
                        foreach (var pp in marisco.Productos)
                            if (pp.CantProduccida > 0)
                            {
                                var flag = await Producto.GetByParametersAsync(context, marisco.Mariscoid, pp.TipoProduccionid, pp.Calibreid, pp.Empaquetadoid);
                                resp.ProductoProduccion.Add(new()
                                {
                                    CantidadProducida = pp.CantProduccida,
                                    Productoid = flag.id
                                });
                            }
                    }


                return resp;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }


        #endregion
    }
}
