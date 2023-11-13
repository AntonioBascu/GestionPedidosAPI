using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPedidos.Data
{
    public class Tinta
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Tipo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Color { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string DondeEsta { get; set; }
    }
}
