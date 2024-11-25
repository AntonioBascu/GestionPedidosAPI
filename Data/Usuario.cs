using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidos.Data
{
    public class Usuario : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string AñoAntiguedad { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string CodigoCliente { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string RazonSocial { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string NombreComercial { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public String Domicilio { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(30)")]
        public String Poblacion { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(30)")]
        public String Provincia { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(6)")]
        public String CodigoPostal { get; set; }
    }
}
