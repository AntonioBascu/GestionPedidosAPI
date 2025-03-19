using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPedidosAPI.Data
{
    public class LineaPedido
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int IDPedido { get; set; }

        [Required]
        public virtual Pedido Pedido { get; set;}

        public string IDEncargado { get; set; }

        public virtual Usuario Encargado { get; set; }

        [Required]
        public int IDArticulo { get; set; }

        [Required]
        public virtual Articulo Articulo { get; set; }

        public TipoGrabado TipoGrabado { get; set;}

        [Column(TypeName = "nvarchar(50)")]
        public string? Tinta { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? SituacionGrabacion { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public DateTime Creado { get; set; }
        [Required]
        public string CreadoPorID { get; set; }
        [Required]
        public virtual Usuario CreadoPor { get; set; }

        public DateTime? Modificado { get; set; }
        public string? ModificadoPorID { get; set; }
        public virtual Usuario ModificadoPor { get; set; }

    }
}
