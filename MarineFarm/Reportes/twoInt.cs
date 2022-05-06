
namespace MarineFarm.Reportes
{
    /// <summary>
    /// almacena dos enteros de manera temporal
    /// </summary>
    public class twoInt
    {
        #region props
        /// <summary>
        /// primer entero
        /// </summary>
        public int entero1 { get; set; }
        /// <summary>
        /// segundo entero
        /// </summary>
        public int entero2 { get; set; }
        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public twoInt()
        {
            this.entero1 = entero2 = 0;
        }
        /// <summary>
        /// para llenarloss directarmente
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        public twoInt(int e1, int e2)
        {
            this.entero1 = e1;
            this.entero2 = e2;
        }
        #endregion
        
    }
}
