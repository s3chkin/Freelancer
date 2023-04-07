using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Services
{
    public class RoleSeeder 
    {

        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<Role> roleManager)
        {
            // Проверка за наличие на роля "Администратор"
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                // Създаване на роля "Администратор"
                var adminRole = new Role { Name = "Admin" };
                await roleManager.CreateAsync(adminRole);

                // Създаване на потребител "admin" и добавяне на роля "Администратор"
                var adminUser = new AppUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "StrongPassword!1");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }


        //public static void Seed(ApplicationDbContext context)
        //{
        //    if (!context.Roles.Any())
        //    {
        //        context.Roles.AddRange(new Role[]
        //        {
        //        new Role{Name = "Admin"},
        //        new Role{Name = "User"},
        //        });

        //        context.SaveChanges();
        //    }
        //}

        public interface IDataBaseSeeder
        {
            Task<bool> HasAnyDataInDBAsync();
            Task InsertDataInDBAsync();
        }
    }
}
