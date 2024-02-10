using Data;
using Laboratorium3_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
// using Laboratorium3_App.Data;

namespace Laboratorium3_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddDefaultIdentity<IdentityUser>()       
            .AddRoles<IdentityRole>()                            
            .AddEntityFrameworkStores<Data.AppDbContext>();   
            //builder.Services.AddTransient<IReservationService, MemoryReservationService>();
            builder.Services.AddTransient<IReservationService, ReservationService>();

            builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();

            builder.Services.AddMemoryCache();
            builder.Services.AddSession(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            

            app.UseMiddleware<LastVisitCookie>();
                        app.UseAuthentication();;

            app.UseAuthentication();                                 
            app.UseAuthorization();                                  
            app.UseSession();                                        
            app.MapRazorPages(); 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}