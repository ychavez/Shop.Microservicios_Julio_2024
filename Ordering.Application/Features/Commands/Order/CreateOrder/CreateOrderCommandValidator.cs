using FluentValidation;

namespace Ordering.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Address).EmailAddress().NotEmpty()
                .WithMessage("La direccion no puede ser vacia oiga");

            RuleFor(x => x.UserName)
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}
