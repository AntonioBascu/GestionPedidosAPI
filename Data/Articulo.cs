using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidosAPI.Data
{
    public class Articulo
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Nombre { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string? Color { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? Referencia { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal? Precio { get; set; }

        public int? Stock { get; set; }

    }
}
