using Application.Common.Interfaces;
using Application.UseCases;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrapper
{
    public class Config
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IOrderServices, OrderServices>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddSingleton<DataContext>();
        }
    }
}
