using Microsoft.EntityFrameworkCore;

using GarageApp.Data;

namespace GarageApp;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        string connectionString = GetConnectionString(builder);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        /* Регистрираме GarageAppDbContext в ASP.NET Core ServiceCollection. Това позволява ASP.NET Core да инстанцира DbContext с конфигуриран ConnectionString и да го подава навсякъде в
        приложението през Dependency Injection */
        builder.Services.AddDbContext<GarageAppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }

    private static string GetConnectionString(IHostApplicationBuilder builder)
    {
        string? connectionString = builder.Configuration.GetConnectionString("SqlServerDev");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            // Ако първия connection string не успее, да се използва този по подразбиране
            connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Default Connection string is not configured!");
        }

        return connectionString;
    }
}
