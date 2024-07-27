using AutoMapper;
using Ordering.Application.Features.Commands.Order.CreateOrder;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
        }
    }
}
