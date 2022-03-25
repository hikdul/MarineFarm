using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// son las empresas clientes. quienes generen pedidos o a quienes se le destinen los pedidos
    /// </summary>
    public class Cliente: ITipo
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del cliente
        /// </summary>
        [Required(ErrorMessage ="El Nombre es necesario")]
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
    }
}
