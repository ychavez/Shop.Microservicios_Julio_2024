using AutoMapper;
using MediatR;
using Ordering.Application.Contracts;


namespace Ordering.Application.Features.Commands.Order.CreateOrder
{
    public class CreateorderCommandHandler
        (IGenericRepository<Domain.Entities.Order> repository, IMapper mapper)
        : IRequestHandler<CreateOrderCommand, int>
    {
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = mapper.Map<Domain.Entities.Order>(request);
           
            
            var newOrder = await repository.AddAsync(order);
            return newOrder.Id;
        }
    }
}
