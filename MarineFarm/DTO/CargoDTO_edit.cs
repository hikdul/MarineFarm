using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para editar los cargos
    /// </summary>
    public class CargoDTO_edit : CargosDTO_in
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Para indicar el sexo del operador
        /// </summary>
        [Range(0, 2)]
        public int sexo { get; set; } = 0;
    }
}
