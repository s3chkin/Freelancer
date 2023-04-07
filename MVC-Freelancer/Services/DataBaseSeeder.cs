using Microsoft.AspNetCore.Identity;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Data;
using Microsoft.EntityFrameworkCore;

namespace MVC_Freelancer.Services
{
    public class DataBaseSeeder : IDataBaseSeeder
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DataBaseSeeder(ApplicationDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
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
            await this.CreateJobsAsync();
            await this.CreateCategoryAsync();
            await this.CreateReservationAsync();
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

        private async Task CreateJobsAsync()
        {
            var job1 = new Job
            {
                Name = "Уеб разработка",
                Price = 100,
                CategoryId = 1,
                DeadLine = DateTime.UtcNow,

            };
            await dbContext.AddAsync(job1);
            await dbContext.SaveChangesAsync();

        }

        private async Task CreateCategoryAsync()
        {
            var restorauntFD = dbContext.Jobs.FirstOrDefault();

            var categories = new Category[] {
            new Category()
            {
                Id= 1,
                 Name = "Гейм девелъпинг"
        },
                        new Category()
            {
                            Id= 2,
                 Name = "Back-end"
        }

            };


            //   restorauntFD.Places.AddRange(places);
            await dbContext.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();




        }

        private async Task CreateReservationAsync()
        {
            AppUser userFD = userManager.Users.OrderBy(x => x.Id).Last();//TODO

            Category placeFD = dbContext.Categories.OrderBy(x => x.Id).Last();
            var time = new DateTime(2022, 12, 23, 17, 45, 0);
            //var reservation = new Reservation()
            //{
            //    UserId = userFD.Id,
            //    PlaceId = placeFD.Id,
            //    Time = time,
            //};

            //await dbContext.AddAsync(reservation);
            await dbContext.SaveChangesAsync();
        }

    }
    public interface IDataBaseSeeder
    {
        Task<bool> HasAnyDataInDBAsync();
        Task InsertDataInDBAsync();
    }
}
