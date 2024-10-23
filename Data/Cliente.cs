using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidos.Data
{
    public class Cliente
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string RazonSocial { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string NombreComercial { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(12)")]
        public String Telefono { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public String Poblacion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public String Provincia { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public String Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String Domicilio { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(6)")]
        public String CodigoPostal { get; set; }
    }
}
