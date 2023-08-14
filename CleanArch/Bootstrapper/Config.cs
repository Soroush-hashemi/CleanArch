using MediatR;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Application.Command.Products.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper
{
    public class Config
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly));

            services.AddSingleton<DataContext>();
        }
    }
}
