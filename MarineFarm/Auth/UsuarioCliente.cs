using MarineFarm.Entitys;

namespace MarineFarm.Auth
{
    /// <summary>
    /// identifica a un usuario que es cliente en el sistema
    /// </summary>
    public class UsuarioCliente
    {
        /// <summary>
        /// datos del usuario
        /// </summary>
        public int Usuarioid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Usuario Usuario { get; set; }
        /// <summary>
        /// empresa a la que pertenece este usuario
        /// </summary>
        public int Clienteid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Cliente Cliente { get; set; }

    }
}
