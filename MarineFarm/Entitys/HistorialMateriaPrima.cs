using MarineFarm.Auth;
using MarineFarm.Data;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{

    /// <summary>
    /// Para mantener el historial de ingresos y egresos de la materia prima
    /// </summary>
    public class HistorialMateriaPrima
    {
        #region props

        /// <summary>
        /// id
        /// </summary>

        [Key]
        public int id { get; set; }
        /// <summary>
        /// marisco que ingresa
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Marisco Marisco { get; set; }
        /// <summary>
        /// Cantidad que ha ingresado
        /// </summary>
        [Range(0, double.MaxValue)]
        public double Cantidad { get; set; }
        /// <summary>
        /// fecha en la que ingreso
        /// </summary>
        public DateTime Fecha { get; set; } = DateTime.Now;
        /// <summary>
        /// usuario que realizo el ingreso
        /// </summary>
        public int Usuarioid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Usuario Usuario { get; set; }
        /// <summary>
        /// afirma si es un ingreso o egreso
        /// </summary>
        public bool Ingreso { get; set; }

        #endregion


        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="Mariscoid"></param>
        /// <param name="Cantidad"></param>
        /// <param name="Ingreso"></param>
        public HistorialMateriaPrima(int Mariscoid, double Cantidad, bool Ingreso)
        {
            this.Mariscoid = Mariscoid;
            this.Cantidad = Cantidad;
            this.Fecha = DateTime.Now;
            this.Ingreso = Ingreso;

        }



        #endregion


        #region agregar
        /// <summary>
        /// para agregar contenido a la tabla
        /// </summary>
        /// <param name="context"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task Add(ApplicationDbContext context, System.Security.Claims.ClaimsPrincipal User)
        {
            try
            {
                var us = await Usuario.GetByEmail(User.Identity.Name, context);
                if (us == null)
                    return;

                //this.Usuario = null;
                this.Usuarioid = us.id;

                context.Add(this);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }


        #endregion

    }
}
