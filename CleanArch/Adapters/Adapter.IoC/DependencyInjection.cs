using Core.Application.Interfaces;
using Core.Application.Mappings;
using Core.Application.Services;
using Core.Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var handlers = AppDomain.CurrentDomain.Load("Core.Application");
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(handlers));

        return services;
    }
}
