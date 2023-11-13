using System.ComponentModel.DataAnnotations;

namespace GestionPedidos.Data
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }
}
