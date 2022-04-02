using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para agregar un nuevo cliente
    /// </summary>
    public class ClienteDTO_in : GTipoDTO_in
    {

      
        /// <summary>
        /// valor o numero de identificacion del cliente
        /// </summary>
        [StringLength(25)]
        public string? RUT { get; set; }

    }
}
