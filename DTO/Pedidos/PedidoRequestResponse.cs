using GestionPedidosAPI.Data;
using GestionPedidosAPI.DTO.LineasPedido;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidosAPI.DTO.Pedidos
{
    public class PedidoRequestResponse
    {
        public int Id { get; set; }

        public string Cliente { get; set; }
       
        public Estado Estado { get; set; }

        public DateTime? EntregaMax { get; set; }

        public virtual ICollection<LineaPedidoRequestResponse> LineasPedido { get; set; }
    }
}
