using Microsoft.EntityFrameworkCore;

using GameZone.Data;

namespace GameZone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("SqlServerDev")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDbContext<GameZoneDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
