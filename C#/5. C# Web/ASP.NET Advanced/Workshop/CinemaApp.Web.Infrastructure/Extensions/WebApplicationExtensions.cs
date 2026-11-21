using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using CinemaApp.Data.Seeding.Utilities;
using Microsoft.Extensions.Configuration;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseDefaultRoles(this WebApplication app, IConfiguration configuration)
    {
        using IServiceScope serviceScope = app.Services.CreateScope();
        IServiceProvider serviceProvider = serviceScope.ServiceProvider;

        string adminEmail = configuration.GetValue<string>("UserSeed:AdminAccount:Email")
            ?? throw new ArgumentException();
        string adminPassword = configuration.GetValue<string>("UserSeed:AdminAccount:Password")
            ?? throw new ArgumentException();

        IdentitySeeder.SeedRoles(serviceProvider);
        IdentitySeeder.SeedAdminUser(serviceProvider, adminEmail, adminPassword);

        return app;
    }
}
