using FluentValidation;

namespace Ordering.Application.Features.Queries.GetOrders
{
    public class GetOrdersListQueryValitator : AbstractValidator<GetOrdersListQuery>
    {
        public GetOrdersListQueryValitator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(2)
                .WithMessage("Nadie se llama con una sola letra, verifique su parametro");
        }
    }
}
