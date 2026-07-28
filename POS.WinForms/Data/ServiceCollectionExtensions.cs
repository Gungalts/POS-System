using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces;
using POS.Application.Services;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;
using POS.Infrastructure.Repositories;

namespace POS.WinForms.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPosServices(this IServiceCollection services, string connectionString)
    {
        // Infrastructure
        services.AddSingleton<IDbConnectionFactory>(
            new SqliteConnectionFactory(connectionString));

        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<ICategoryRepository, CategoryRepository>();
        services.AddSingleton<ISupplierRepository, SupplierRepository>();
        services.AddSingleton<ICustomerRepository, CustomerRepository>();

        // Application
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<ICustomerService, CustomerService>();

        // Forms
        services.AddTransient<Forms.MainForm>();
        services.AddTransient<Forms.Products.CategoryForm>();
        services.AddTransient<Forms.Products.SupplierForm>();
        services.AddTransient<Forms.Products.CustomerForm>();

        return services;
    }
}