using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para agregar un nuevo cliente
    /// </summary>
    public class ClienteDTO_in
    {

        /// <summary>
        /// nombre de la empresa o cliente
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
        /// valor o numero de identificacion del cliente
        /// </summary>
        [StringLength(25)]
        public string? RUT { get; set; }

    }
}
