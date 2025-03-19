using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidosAPI.Data
{
    public class Pedido
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Cliente { get; set; }
        
        [Required]
        public Estado Estado { get; set; }

        public DateTime? EntregaMax { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Vendedor { get; set; }

        [Required]
        public DateTime Creado { get; set; }
        [Required]
        public string CreadoPorID { get; set; }
        [Required]
        public virtual Usuario CreadoPor { get; set; }

        public DateTime? Modificado { get; set; }
        public string? ModificadoPorID { get; set; }
        public virtual Usuario ModificadoPor { get; set; }
        
        [Required]
        public virtual ICollection<LineaPedido> LineasPedido { get; set; }
    }
}
