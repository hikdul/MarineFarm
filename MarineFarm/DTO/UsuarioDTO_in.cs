using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// para generar un nuevo usuario
    /// </summary>
    public class UsuarioDTO_in
    {

        #region props
       
        /// <summary>
        /// nombre del usuario
        /// </summary>
        [StringLength(50)]
        [Required(ErrorMessage = "El Nombre Es Necesario")]
        public string Nombre { get; set; }
        /// <summary>
        /// rut
        /// </summary>
        [StringLength(12)]
        public string rut { get; set; } = "";
        /// <summary>
        /// Email de ingreso al sistema
        /// </summary>
        [EmailAddress(ErrorMessage = "No Es Una Direccion De Correo Valida")]
        [Required(ErrorMessage = "El Correo Electronico es necesario")]
        public string Email { get; set; }
        /// <summary>
        /// telefono
        /// </summary>
        public string Telefono { get; set; } = "";
        /// <summary>
        /// para almacenar los roles
        /// 3 => AdmoSistema ==> Administrador del sistema
        /// 2 => Gerenteplanta ==> Genente de planta
        /// 1 => Superv ==> Supervisor de Planta
        /// 0 => Cliente ==> Cliente`
        /// </summary>
        public int LvlRol { get; set; }
        /// <summary>
        /// Contraseña Inicial con la que el sistema apertura la cuenta
        /// </summary>
        public string Psw { get; set; }
        #endregion
    }
}
