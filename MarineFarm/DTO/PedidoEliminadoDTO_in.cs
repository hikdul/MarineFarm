using System.ComponentModel.DataAnnotations;

namespace MarineFarm.DTO
{
    /// <summary>
    /// datos que se deben de enviar al querer eliminar un pedido
    /// </summary>
    public class PedidoEliminadoDTO_in
    {
        /// <summary>
        /// id del pedido que se va a eliminar
        /// </summary>
        [Required(ErrorMessage ="Indique el pedido que desea eliminar")]
        public  int EliminadoId { get; set; }
        /// <summary>
        /// Razon por la que se eliminara el pedido
        /// </summary>
        [Required(ErrorMessage ="Explique el por que va a eliminar este pedido")]
        [MinLength(10,ErrorMessage ="Debe de ingresar al menos 10 caracteres'")]
        public string Razon { get; set; }

    }
}
