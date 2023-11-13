using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidos.Data
{
    public class Pedido
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime FCreado { get; set; }

        public DateTime FEntregaMax { get; set; }

        public DateTime FPasadoTaller { get; set; }

        public double Precio { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        [Required]
        public Estado Estado { get; set; }
        
        public Usuario ModificadoPor {  get; set; }

        [Required]
        public ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
