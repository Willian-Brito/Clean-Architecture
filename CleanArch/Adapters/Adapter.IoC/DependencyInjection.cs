using Core.Application.Interfaces;
using Core.Application.Mappings;
using Core.Application.Services;
using Core.Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infra.Data.Identity;
using Core.Domain.Account;

namespace Adapter.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
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

        #region Redirecionamento Login
        services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");
        #endregion

        #region Services
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        #endregion

        #region Auth
        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
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
