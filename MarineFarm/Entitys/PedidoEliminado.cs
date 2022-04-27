using MarineFarm.Auth;
using System.ComponentModel.DataAnnotations;

namespace MarineFarm.Entitys
{
    /// <summary>
    /// para almacenar los datos de un pedido eliminado
    /// </summary>
    public class PedidoEliminado
    {
        #region props
        
        /// <summary>
        /// identificador
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// razon por la que se elimina el pedido
        /// </summary>
        [Required]
        [StringLength(500)]
        [MinLength(10)]
        public string Razon  { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Pedido Eliminado{ get; set; }
        /// <summary>
        /// pedido que se esta eliminando
        /// </summary>
        public int Eliminadoid { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Usuario QuienElimino { get; set; }
        /// <summary>
        /// usuario que elimino el pedido
        /// </summary>
        public int QuienEliminoid { get; set; }

        #endregion
    }
}
