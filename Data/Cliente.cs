using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidosAPI.Data
{
    public class Cliente
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string CodigoCliente { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Domicilio { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Poblacion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Provincia { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        public string CodigoPostal { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string AnoAntiguedad { get; set; }
    }
}
