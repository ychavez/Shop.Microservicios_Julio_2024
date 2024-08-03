
using Basket.Api.Repositories;
using Inventory.Grpc.Protos;

namespace Basket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddStackExchangeRedisCache(x =>
            x.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString"));

            builder.Services.AddScoped<IBasketRepository, BasketRepository>();

            builder.Services.AddGrpcClient<Existence.ExistenceClient>
                (x => x.Address = new Uri(builder.Configuration["GrpcSettings:HostAddress"]!));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
