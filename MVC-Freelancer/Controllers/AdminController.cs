using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;

namespace MVC_Freelancer.Controllers
{
    public class AdminController : BaseController
    {
        public readonly ApplicationDbContext db;

        public AdminController(ApplicationDbContext db, UserManager<AppUser> um) : base(um)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio() 
        { 
            return View();
        }
        public IActionResult UsersList()
        {
            var usersWithRoles = (from user in db.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      //RoleNames = (from userRole in user.Roles
                                      //             join role in db.Roles on userRole.RoleId
                                      //             equals role.Id
                                      //             select role.Name).ToList()
                                  }).ToList().Select(p => new UserViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      //Role = string.Join(",", p.RoleNames)
                                  });
            return View(usersWithRoles);
        }
    }
}
