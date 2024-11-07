using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionPedidos.Data
{
    public class Pago
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string NombrePropietarioTarjeta { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string NumeroTarjeta { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public string FechaCaducidad { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public string CodigoSeguridad { get; set; }
    }
}
