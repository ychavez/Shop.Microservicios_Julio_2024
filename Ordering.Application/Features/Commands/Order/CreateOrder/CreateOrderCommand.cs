using MediatR;

namespace Ordering.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string UserName { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Email { get; set; }
        public int PaymentMethod { get; set; }
    }
}
