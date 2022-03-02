namespace MarineFarm.DTO
{
    /// <summary>
    /// para retornar un error en un campo o sitio
    /// </summary>
    public class Err
    {
        #region props

        /// <summary>
        /// campo donde ocurre el error
        /// </summary>
        public string Campo { get; set; } = string.Empty;
        /// <summary>
        /// error o problema
        /// </summary>
        public string Error { get; set; } = string.Empty;

        #endregion


        #region ctor

        /// <summary>
        /// empty
        /// </summary>
        public Err()
        {
            this.Campo = this.Error = string.Empty;
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="error"></param>
        public Err(string campo, string error)
        {
            this.Campo = campo;
            this.Error = error;
        }

        #endregion

    }
}
