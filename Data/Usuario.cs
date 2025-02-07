using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidosAPI.Data
{
    public class Usuario : IdentityUser
    {
        public virtual ICollection<LineaPedido> TrabajosAsignados { get; set; }
    }
}
