using MarineFarm.Helpers;
using System.ComponentModel.DataAnnotations;



namespace MarineFarm.Entitys
{
    /// <summary>
    /// Clase para almacenar los datos de mis mariscos
    /// </summary>
    public class Marisco : ITipo
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
