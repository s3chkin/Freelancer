using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Services;

namespace MVC_Freelancer
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
            }
            )
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            //builder.Services.AddDbContext<AppI>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            builder.Services.AddAuthentication().AddGoogle(
                opts =>
                {
                    opts.ClientId = "584315873580-vupubqnalkd8qmih96unubt2408v27l6.apps.googleusercontent.com";
                    opts.ClientSecret = "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";
                    opts.SignInScheme = IdentityConstants.ExternalScheme;
                });
            builder.Services.AddControllersWithViews();

           
            builder.Services.AddTransient<IDataBaseSeeder, DataBaseSeeder>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(x=>
            //    {
            //        x.LogoutPath = "/Home/index/";
            //    });
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}