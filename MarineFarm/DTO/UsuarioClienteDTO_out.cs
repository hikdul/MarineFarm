namespace MarineFarm.DTO
{
    /// <summary>
    /// datos que se mostraran del usuario cliente
    /// </summary>
    public class UsuarioClienteDTO_out: UsuarioDTO_out
    {
        /// <summary>
        /// indica el nombre de la empresa a la que pertenece este usuario
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// indica el rut del cliente
        /// </summary>
        public string RUT { get; set; }

    }
}
