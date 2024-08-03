using AutoMapper;
using EventBus.Mesagges.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.Commands.Order.CreateOrder;

namespace Ordering.Api.Events
{
    public class CheckoutEventConsumer(IMapper mapper, IMediator mediator) : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = mapper.Map<CreateOrderCommand>(context.Message);
            await mediator.Send(command);
        }
    }
}
