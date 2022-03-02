namespace MarineFarm.DTO
{
    /// <summary>
    /// data que se entrega al hacer la consulta
    /// </summary>
    public class HistorialMateriaPrimaDTO_out
    {

        #region props

        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Marisco que ingreso
        /// </summary>
        public string Marisco { get; set; }
        /// <summary>
        /// Cantidad que ha ingresado
        /// </summary>
        public double Cantidad { get; set; }
        /// <summary>
        /// fecha en la que ingreso
        /// </summary>
        public DateTime Fecha { get; set; } 
        /// <summary>
        /// Nombre de quien registro
        /// </summary>
        public string NombreQuienRegistro { get; set; }
        /// <summary>
        /// rut de quien registro
        /// </summary>
        public string rutQuienRegistro { get; set; }
        /// <summary>
        /// afirma si es un ingreso o egreso
        /// </summary>
        public bool Ingreso { get; set; }

        #endregion

        #region ctor
        /// <summary>
        /// empty
        /// </summary>
        public HistorialMateriaPrimaDTO_out()
        {
            this.Marisco = this.NombreQuienRegistro = this.rutQuienRegistro = String.Empty;
            this.Cantidad = 0;
            this.Ingreso = true;
            this.id = 0;
        }

        #endregion

    }
}
