using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidos.Data
{
    public class Usuario
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }

        public bool Taller { get; set; }
    }
}
