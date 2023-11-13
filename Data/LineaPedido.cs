using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPedidos.Data
{
    public class LineaPedido
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int IdPedido { get; set; }

        [Required]
        public Pedido Pedido { get; set;}

        public int Precio { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string AreaGrabado { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string SituacionGrabacion { get; set; }

        [Required]
        public int Cantidad { get; set; }

    }
}
