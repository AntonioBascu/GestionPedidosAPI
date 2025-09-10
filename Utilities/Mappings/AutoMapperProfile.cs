namespace GestionPedidosAPI.Utilities.Mappings
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Data.Pedido, DTO.Pedidos.PedidoRequestResponse>()
                .ReverseMap();

            CreateMap<Data.LineaPedido, DTO.LineasPedido.LineaPedidoRequestResponse>()
                .ReverseMap();
        }
    }
}
