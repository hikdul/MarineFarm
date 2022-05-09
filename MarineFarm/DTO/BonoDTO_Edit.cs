
using MarineFarm.DTO;

namespace MarineFarm.DTO
{
    /// <summary>
    /// Clase para editar los bonos en las vistas
    /// </summary>
    public class BonoDTO_Edit:BonoDTO_in
    {
        /// <summary>
        /// id del elemento a editar
        /// </summary>
        /// <value></value>
        public int id { get; set; }
    }
}