using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidos.Data
{
    public class Articulo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Referencia { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Color { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string DondeEsta { get; set;}
    }
}
