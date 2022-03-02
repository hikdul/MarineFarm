using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para ingresar valores en el caso de clase dependientes de la interface ITipo
    /// </summary>
    public class GTipoDTO_in
    {
        #region props
        /// <summary>
        /// nombre del marisco
        /// </summary>
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Name { get; set; }
        /// <summary>
        /// descripcion
        /// </summary>
        [StringLength(50, ErrorMessage = "maximo {0} caracteres")]
        public string Desc { get; set; } = "";
        #endregion
    }
}
