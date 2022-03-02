using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// para indicar el numero de unidades ingresado por paquete
    /// </summary>
    public class Empaquetado : ITipo
    {
        #region propiedades
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// nombre del marisco
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// descripcion
        /// </summary>
        [StringLength(50)]
        public string Desc { get; set; } = "";
        /// <summary>
        /// si esta o no activo en base de datos
        /// </summary>
        public bool act { get; set; } = true;
        #endregion

    }
}
