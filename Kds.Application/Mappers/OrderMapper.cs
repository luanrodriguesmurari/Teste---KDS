using AutoMapper;
using Kds.Domain.Entities.Orders;

namespace Kds.Application.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<CreateOrderRequest, Order>().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.Items, opt => opt.Ignore());
            CreateMap<UpdateOrderRequest, Order>().ForMember(dest => dest.Id, opt => opt.Ignore()).ForMember(dest => dest.Items, opt => opt.Ignore());
            CreateMap<OrderItem, OrderItemResponse>().ReverseMap();
            CreateMap<CreateOrderItemRequest, OrderItem>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateOrderItemRequest, OrderItem>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}