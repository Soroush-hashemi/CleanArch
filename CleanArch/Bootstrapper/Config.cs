using MediatR;
using Domain.Repositories;
using Infrastructure.Repositories;
using Application.Command.Products.Create;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using Application.Command.Products.Edit;
using Application.Query.Products.GetList;
using Application.Query.Products.GetById;
using Application.Command.Orders.Create;
using Application.Command.Shared;
using FluentValidation;
using Application.Command.SmsService;
using Application.Command.Products.Delete;
using Domain;
using Application.Command.DomainService;
using Domain.Service;

namespace Bootstrapper
{
    public class Config
    {
        public static void Init(IServiceCollection services, string ConnectionStrings)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductExist , ProductExistDomainService>();
            services.AddTransient<IUserExist , UserExistDomainService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(EditProductCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeleteProductCommand).Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateOrderCommand).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidatorBehavior<,>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetProductListQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetProductByIdQuery).Assembly));

            services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(EditProductCommandValidator).Assembly);

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(ConnectionStrings);
            });

            services.AddScoped<ISmsService, SmsService>();
        }
    }
}
