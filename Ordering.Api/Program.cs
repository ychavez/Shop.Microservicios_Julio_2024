

namespace Ordering.Api
{
    using EventBus.Mesagges.Common;
    using MassTransit;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Ordering.Api.Events;
    using Ordering.Application.Contracts;
    using Ordering.Application.Extensions;
    using Ordering.Infrastructure.Persistence;
    using Ordering.Infrastructure.Repositories;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(
                x =>
                {

                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(builder.Configuration.GetValue<string>("Identity:Key")!)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


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

            builder.Services.AddMassTransit(
                x =>
                {
                    x.AddConsumer<CheckoutEventConsumer>();

                    x.UsingRabbitMq(
                        (ctx, cfg) =>
                        {
                            cfg.Host(builder.Configuration["EventBussSettings:HostAddress"]);
                            cfg.ReceiveEndpoint(

                                EventBusConstants.BasketCheckoutQueue,
                                x => x.ConfigureConsumer<CheckoutEventConsumer>(ctx));
                        });
                });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
