using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementTask.Domain.Repositories;
using ProductManagementTask.Infrastructure.Context;
using ProductManagementTask.Infrastructure.Repositories;

namespace ProductManagementTask.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IStockUnitRepository, StockUnitRepository>();
        services.AddScoped<IStockTypeRepository, StockTypeRepository>();
        services.AddScoped<IUnitOfWork>(cfr => cfr.GetRequiredService<ApplicationDbContext>());

        return services;



    }
}
