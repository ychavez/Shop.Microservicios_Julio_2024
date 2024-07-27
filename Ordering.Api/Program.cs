

namespace Ordering.Api
{
using Microsoft.EntityFrameworkCore;
    using Ordering.Application.Contracts;
    using Ordering.Application.Extensions;
using Ordering.Infrastructure.Persistence;
    using Ordering.Infrastructure.Repositories;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.RegisterApplication();
            builder.Services.AddDbContext<OrderContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration
                        .GetConnectionString("OrderingConnection"));
                });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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
