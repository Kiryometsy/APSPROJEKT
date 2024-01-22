using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ASPPROJEKT.Controllers;
using Data;
using ASPPROJEKT.Services;
using ASPPROJEKT.Models;


namespace ASPPROJEKT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<Data.AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Data.AppDbContext>();

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

            builder.Services.AddScoped<PhotoService>();
            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<AddressService>();


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMiddleware<LastVisitCookie>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "photo",
                pattern: "Photo/{action=Index}/{id?}",
                defaults: new { controller = "Photo" });

            app.Run();
        }
    }
}
