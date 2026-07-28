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
        services.AddSingleton<IPurchaseRepository, PurchaseRepository>();
        services.AddSingleton<ISalesRepository, SalesRepository>();
        services.AddSingleton<IStockLedgerRepository, StockLedgerRepository>();
        services.AddSingleton<IStockOpnameRepository, StockOpnameRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();

        // Sesi user yang login (satu instance selama aplikasi berjalan).
        services.AddSingleton<UserSession>();

        // Application
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<ISalesService, SalesService>();
        services.AddScoped<IStockLedgerService, StockLedgerService>();
        services.AddScoped<IStockOpnameService, StockOpnameService>();
        services.AddScoped<IUserService, UserService>();

        // Forms
        services.AddTransient<Forms.MainForm>();
        services.AddTransient<Forms.Products.CategoryForm>();
        services.AddTransient<Forms.Products.SupplierForm>();
        services.AddTransient<Forms.Products.CustomerForm>();
        services.AddTransient<Forms.Products.ProductForm>();
        services.AddTransient<Forms.Cashier.KasirForm>();
        services.AddTransient<Forms.Purchasing.PembelianForm>();
        services.AddTransient<Forms.Purchasing.PembayaranHutangForm>();
        services.AddTransient<Forms.Stock.StockOpnameForm>();
        services.AddTransient<Forms.Stock.StockLedgerForm>();
        services.AddTransient<Forms.Login.LoginForm>();
        services.AddTransient<Forms.Login.UserForm>();

        return services;
    }
}