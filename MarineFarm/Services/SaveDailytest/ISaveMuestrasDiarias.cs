using MarineFarm.Entitys;

namespace MarineFarm.Services
{
    /// <summary>
    /// para almacenar las muestras diarias
    /// </summary>
    public interface ISaveMuestrasDiarias
    {
        /// <summary>
        /// funcion que almacena las muestras diarias
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public Task Save(MuestraDiaria ins);
    }
}
