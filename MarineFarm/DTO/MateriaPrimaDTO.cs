using MarineFarm.Entitys;

namespace MarineFarm.DTOs
{
    /// <summary>
    /// una copia de lo que se puede entregar de este elemento en la entidad
    /// </summary>
    public class MateriaPrimaDTO
    {

        #region prop
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// marisco al que pertenece
        /// </summary>
        public int Mariscoid { get; set; }
        /// <summary>
        /// prop de nav
        /// </summary>
        public Marisco Marisco { get; set; }
        /// <summary>
        /// cantidad del marisco
        /// </summary>

        public double Cantidad { get; set; } = 0;

        #endregion

    }
}
