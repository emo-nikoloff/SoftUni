using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using CinemaApp.Data.Seeding.Utilities;

namespace CinemaApp.Web.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseDefaultRoles(this WebApplication app)
    {
        using IServiceScope serviceScope = app.Services.CreateScope();
        IServiceProvider serviceProvider = serviceScope.ServiceProvider;

        IdentitySeeder.SeedRoles(serviceProvider);

        return app;
    }
}
