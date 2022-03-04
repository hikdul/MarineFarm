using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// Cargos que se almacenan por equipo de trabajo
    /// </summary>
    public class Cargos :  ITipo
    {
        #region props
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del cargo
        /// </summary>
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        /// <summary>
        /// descripcion del cargo
        /// </summary>
        [StringLength(50)]
        public string Desc { get; set; } = string.Empty;
        /// <summary>
        /// si el cargo esta activo o no
        /// </summary>
        public bool act { get; set; } = true;
        /// <summary>
        /// Cantidad Operadores Necesaria
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CantOperadoresNecesario { get; set; } = 1;
        #endregion
    }
}
