using System.ComponentModel.DataAnnotations;

namespace GestionPedidos.Data
{
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(11)]
        public String Telefono { get; set; }

        [Required]
        [StringLength(200)]
        public String Email { get; set; }

        [Required]
        [StringLength(100)]
        public String Direccion { get; set; }
    }
}
