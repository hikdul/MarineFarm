namespace MarineFarm.Helpers
{
    /// <summary>
    /// interface de usos diarios
    /// </summary>
    public interface Iid
    {
        /// <summary>
        /// identificador
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// si esta activo o no en base de datos
        /// </summary>
        public bool act { get; set; }
    }
}
