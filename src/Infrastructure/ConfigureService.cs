using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using practice.Application.Common.Interfaces;
using practice.Domain.Identity;
using practice.Infrastructure.Persistance;

namespace practice.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

        // Registers IApplicationDbContext as a scoped service, using the AppDbContext implementation
        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        // Configures identity services using AppUser and AppRole, with AppDbContext as the store
        services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

        // Adds the AppDbContextInitialiser as a scoped service
        services.AddScoped<AppDbContextInitialiser>();

        return services;
    }
}
