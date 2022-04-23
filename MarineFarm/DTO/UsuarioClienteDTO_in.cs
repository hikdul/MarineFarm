using MarineFarm.DTO;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// Para generar un nuevo usuario
    /// </summary>
    public class UsuarioClienteDTO_in: UsuarioDTO_in
    {

        /// <summary>
        /// indica el cliente a que pertenece este usuario
        /// </summary>
        [Required]
        public int Clienteid { get; set; }
    }
}
