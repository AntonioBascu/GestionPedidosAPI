namespace GestionPedidosAPI.Utilities.Models
{
    public class PedidoModel
    {
        public String Cliente { get; set; }

        public DateOnly EntregaMax { get; set; }

        public virtual ICollection<LineaPedidoModel> LineasPedido { get; set; }
    }
}
