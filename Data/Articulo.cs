using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidos.Data
{
    public class Articulo
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string? Referencia { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? PrecioSinIva { get; set; }

        [Required]
        public int? Stock { get; set; }

    }
}
