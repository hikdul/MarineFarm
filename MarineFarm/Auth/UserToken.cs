namespace MarineFarm.Auth
{
    /// <summary>
    /// token de usuario dentro de la aplicacion
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// fecha de expiracion
        /// </summary>
        public DateTime Expiracion { get; set; }
    }
}
