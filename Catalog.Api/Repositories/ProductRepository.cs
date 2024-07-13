using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ICatalogContext catalogContext;
        public ProductRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }
        public async Task CreateProduct(Product product)
        {
            await catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var product = await catalogContext.Products.Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (product is null)
                return false;

            DeleteResult deleteResult = await catalogContext.Products.DeleteOneAsync(x => x.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public async Task<Product> GetProductById(string id)
         => await catalogContext.Products.Find(x => x.Id == id)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await catalogContext.Products.Find(x => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResults = await catalogContext.
                Products.ReplaceOneAsync(filter: x => x.Id == product.Id, product);

            return updateResults.IsAcknowledged && updateResults.ModifiedCount > 0;
        }
    }
}
