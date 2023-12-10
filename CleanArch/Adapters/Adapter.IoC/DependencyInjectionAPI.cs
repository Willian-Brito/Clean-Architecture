using Core.Application.Interfaces;
using Core.Application.Mappings;
using Core.Application.Services;
using Core.Domain.Account;
using Core.Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Identity;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adapter.IoC;
public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
    {
        #region Database
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        #endregion

        #region Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        #endregion

        #region Services
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        #endregion

        #region Auth
        services.AddScoped<IAuthenticate, AuthenticateService>();
        #endregion

        #region Auto Mapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        #endregion

        #region Mediator
        var handlers = AppDomain.CurrentDomain.Load("Core.Application");
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(handlers));
        #endregion

        return services;
    }
}
