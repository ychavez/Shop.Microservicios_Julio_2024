﻿using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        readonly IConfiguration configuration;
        public CatalogContext(IConfiguration configuration)
        {
            this.configuration = configuration;

            var client = new MongoClient(
                configuration.GetValue<string>("DatabaseSettings:ConnectionString")
                );

            var database = client.GetDatabase(
                configuration.GetValue<string>("DatabaseSettings:DatabaseName")
                );

            Products = database.GetCollection<Product>("DatabaseSettings:CollectionName");
        }
        public IMongoCollection<Product> Products { get; }
    }
}

