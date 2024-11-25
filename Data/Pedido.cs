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
        public string CreadoPorID { get; set; }
        [Required]
        public virtual Usuario CreadoPor { get; set; }

        public DateTime Modificado { get; set; }
        public string ModificadoPorID { get; set; }
        public virtual Usuario ModificadoPor { get; set; }

        public DateTime EntregaMax { get; set; }

        public double Precio { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Vendedor { get; set; }

        [Required]
        public string IdCliente { get; set; }
        [Required]
        public virtual Usuario Cliente { get; set; }

        [Required]
        public Estado Estado { get; set; }

        [Required]
        public virtual ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
