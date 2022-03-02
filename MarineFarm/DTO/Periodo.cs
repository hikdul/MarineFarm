namespace MarineFarm.DTOs
{
    /// <summary>
    /// periodo para usos multiples
    /// </summary>
    public class Periodo
    {
        #region props
        /// <summary>
        /// inicio del periodo
        /// </summary>
        public DateTime Inicio { get; set; }
        /// <summary>
        /// fin
        /// </summary>
        public DateTime Fin { get; set; }

        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public Periodo()
        {
            this.Inicio = this.Fin = DateTime.Now;
        }
        /// <summary>
        /// para ingresar los datos de un periodo
        /// </summary>
        /// <param name="Inicio"></param>
        /// <param name="Fin"></param>
        public Periodo(DateTime Inicio, DateTime Fin)
        {
            this.Inicio= Inicio;
            this.Fin = Fin;
            if (!Validate())
                this.Inicio = this.Fin = DateTime.Now;
        }


        #endregion

        #region validate
        /// <summary>
        /// validacion
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return this.Inicio <= this.Fin;
        }

        #endregion


    }
}
