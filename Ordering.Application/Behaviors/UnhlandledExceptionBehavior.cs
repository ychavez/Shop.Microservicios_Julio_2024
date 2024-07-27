using MediatR;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Ordering.Application.Behaviors
{
    public class UnhlandledExceptionBehavior<TRequest, TResponse>
        (ILogger<TRequest> logger)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {

                logger.LogError(ex, $"Excepcion no controlada para la peticion {typeof(TRequest).Name}");
                throw;
            }
        }
    }
}
