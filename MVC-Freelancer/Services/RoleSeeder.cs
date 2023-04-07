using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Services
{
    public class RoleSeeder : IDataBaseSeeder
    {

        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleSeeder(ApplicationDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public async Task<bool> HasAnyDataInDBAsync() =>
                   await roleManager.Roles.AnyAsync();

        public async Task InsertDataInDBAsync()
        {
            await this.CreateRolesAsync();
            await this.RegisterUsersAsync();

        }

        private async Task CreateRolesAsync()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));//.GetAwaiter().GetResult();
            await roleManager.CreateAsync(new IdentityRole("Waiter"));
        }

        private async Task RegisterUsersAsync()
        {
            var user1 = new AppUser
            {
                UserName = "Administrator",
                FirstName = "Admin",
                Email = "admin@gmail.com",
            };

            var user2 = new AppUser
            {
                UserName = "SimpleUser",
                Email = "user0000@abv.bg",
            };
            var pwd = "1234Aa%";

            await userManager.CreateAsync(user1, pwd);
            await userManager.CreateAsync(user2, pwd);
            await userManager.AddToRoleAsync(user1, "Admin");
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
