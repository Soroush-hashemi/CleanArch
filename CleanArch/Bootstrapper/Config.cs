using MediatR;
using Domain.Repositories;
using Infrastructure.PersistenceMemory;
using Infrastructure.Repositories;
using Application.Command.Products.Create;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace Bootstrapper
{
    public class Config
    {
        public static void Init(IServiceCollection services, string ConnectionStrings)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(ConnectionStrings);
            });

            services.AddSingleton<DataContext>();
        }
    }
}
