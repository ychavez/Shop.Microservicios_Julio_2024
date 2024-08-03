using Grpc.Core;
using Inventory.Grpc.Protos;

namespace Inventory.Grpc.Services
{
    public class ExistenceService : Existence.ExistenceBase
    {
        public override Task<productEcistenceReply> checkExistence(productRequest request, ServerCallContext context)
        {
            // logica de negocios
            return Task.FromResult(new productEcistenceReply() { ProductQty = 12 });
        }
    }
}
