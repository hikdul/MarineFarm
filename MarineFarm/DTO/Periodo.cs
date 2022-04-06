namespace MarineFarm.DTO
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

        #region Comprobar dias validos
        /// <summary>
        /// para que me calcule el numero de dias en base a un dia y una fecha
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="cantidadDiasASumar"></param>
        /// <returns></returns>
        public static DateTime DiasValidos(DateTime inicio, double cantidadDiasASumar)
        {
            int DiasPorSemana = 5;
            int band = (int)cantidadDiasASumar;
            band = band / DiasPorSemana;
            cantidadDiasASumar += band;
            DateTime respuesta;
            
            if(cantidadDiasASumar  > 0)
                respuesta = inicio.AddDays(cantidadDiasASumar);
            else
                respuesta = inicio.AddDays(1);

            if(respuesta.DayOfWeek == DayOfWeek.Sunday)
                respuesta = respuesta.AddDays(1);
            if(DiasPorSemana < 6 && respuesta.DayOfWeek == DayOfWeek.Saturday)
                respuesta = respuesta.AddDays(2);

            return respuesta;
        }


        #endregion

    }
}
