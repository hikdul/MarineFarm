namespace MarineFarm.Helpers
{
    /// <summary>
    /// interface de usos varios
    /// </summary>
    public interface ITipo : Iid
    {
        /// <summary>
        /// nombre del elemento
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// descripcion del elemento
        /// </summary>
        public string Desc { get; set; }
    }
}
