using FluentValidation;
using FullMono.Service.Services;
using FullMono.Service.Validators;
using FullMono.Shared.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FullMono.Repository.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IValidator<OrderDto>, OrderDtoValidator>();
            services.AddTransient<IValidator<CustomerDto>, CustomerDtoValidator>();
            services.AddTransient<IValidator<ProductDto>, ProductDtoValidator>();
            services.AddTransient<IValidator<OrderItemDto>, OrderItemDtoValidator>();
        }
    }
}
