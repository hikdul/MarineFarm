using MarineFarm.Data;
using MarineFarm.Helpers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// son las empresas clientes. quienes generen pedidos o a quienes se le destinen los pedidos
    /// </summary>
    public class Cliente : ITipo
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del cliente
        /// </summary>
        [Required(ErrorMessage = "El Nombre es necesario")]
        [StringLength(25)]
        public string Name { get; set; }
        /// <summary>
        /// alguna descripcion
        /// </summary>
        [StringLength(100)]
        public string? Desc { get; set; }
        /// <summary>
        /// si el cliente se encuentra activo o no
        /// </summary>
        public bool act { get; set; } = true;
        /// <summary>
        /// valor o numero de identificacion del cliente
        /// </summary>
        [StringLength(25)]
        public string? RUT { get; set; }
        #endregion


        #region obtener por email
        /// <summary>
        /// para obtener los datos de un cliente en base a su email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<Cliente> ClienteByEmail(string email, ApplicationDbContext context)
        {
            try
            {
                var ent = await context.UsuarioClientes
                    .Include(y => y.Cliente)
                    .Include(y => y.Usuario)
                    .Where(x => x.Usuario.Email == email)
                    .FirstOrDefaultAsync();

                if (ent == null || ent.Usuario == null || ent.Usuario.id < 1)
                    return null;

                return ent.Cliente;

            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee.Message);
            }
            return null;
        }

        #endregion


    }
}
