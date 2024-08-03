using AutoMapper;
using EventBus.Mesagges.Events;
using Ordering.Application.Features.Commands.Order.CreateOrder;
using Ordering.Application.Features.Queries.GetOrders;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<Order, OrdersViewModel>().ReverseMap();
            CreateMap<BasketCheckoutEvent, CreateOrderCommand>().ReverseMap();
        }
    }
}
