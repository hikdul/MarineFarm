using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// para la descripcion de un equipo de trabajo
    /// </summary>
    public class Turnos : ITipo
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// active
        /// </summary>
        public bool act { get; set; } = true;
        /// <summary>
        /// nombre del turno
        /// </summary>
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        /// <summary>
        /// descripcion del turno
        /// </summary>
        [StringLength(100)]
        public string Desc { get; set; } = String.Empty;
    }
}
