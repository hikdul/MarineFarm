namespace MarineFarm.DTO
{
    /// <summary>
    /// datos que se muestran sobre un usuario a nivel publico
    /// </summary>
    public class UsuarioDTO_out
    {
        #region props
        /// <summary>
        /// id 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// nombre del usuario
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// rut
        /// </summary>
        public string rut { get; set; } = "";
        /// <summary>
        /// Email de ingreso al sistema
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// telefono
        /// </summary>

        public string Telefono { get; set; } = "";
        /// <summary>
        /// para almacenar los roles
        /// => AdmoSistema ==> Administrador del sistema
        /// => Gerenteplanta ==> Genente de planta
        /// => Superv ==> Supervisor de Planta
        /// => Cliente ==> Cliente
        /// </summary>
        public string Rol { get; set; }

        #endregion

    }
}
