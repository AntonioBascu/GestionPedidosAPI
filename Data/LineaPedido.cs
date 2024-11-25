using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPedidos.Data
{
    public class LineaPedido
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int IDPedido { get; set; }

        [Required]
        public virtual Pedido Pedido { get; set;}
        
        [Required]
        public int IDArticulo { get; set; }

        [Required]
        public virtual Articulo Articulo { get; set; }

        [Required]
        public TipoGrabado TipoGrabado { get; set;}

        [Required]
        public string Tinta { get; set; }

        public bool DosCaras { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string SituacionGrabacion { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public DateTime Modificado { get; set; }

        public string ModificadoPorID { get; set; }
        public virtual Usuario ModificadoPor { get; set; }

    }
}
