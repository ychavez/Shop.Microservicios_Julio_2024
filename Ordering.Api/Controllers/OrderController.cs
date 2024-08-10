using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Commands.Order.CreateOrder;
using Ordering.Application.Features.Queries.GetOrders;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderCommand command)
            => await mediator.Send(command);

        [HttpGet("{userName}")]
        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Jefe,otroRol")]
        public async Task<ActionResult<List<OrdersViewModel>>> GetOrders(string userName)
            => await mediator.Send(new GetOrdersListQuery { UserName = userName });
    }
}
