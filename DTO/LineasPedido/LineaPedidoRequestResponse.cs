using GestionPedidosAPI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPedidosAPI.DTO.LineasPedido
{
    public class LineaPedidoRequestResponse
    {
        public int Id { get; set; }

        public string Articulo { get; set; }

        public int Cantidad { get; set; }

        public string? Tinta { get; set; }

        public string? SituacionGrabacion { get; set; }
    }
}
