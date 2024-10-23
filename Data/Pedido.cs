using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidos.Data
{
    public class Pedido
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public DateTime Creado { get; set; }
        [Required]
        public int CreadoPorID { get; set; }
        [Required]
        public Usuario CreadoPor { get; set; }

        public DateTime Modificado { get; set; }
        public int ModificadoPorID { get; set; }
        public Usuario ModificadoPor { get; set; }

        public DateTime EntregaMax { get; set; }

        public double Precio { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Vendedor { get; set; }

        [Required]
        public int IdCliente { get; set; }
        [Required]
        public Cliente Cliente { get; set; }

        [Required]
        public Estado Estado { get; set; }

        [Required]
        public ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
