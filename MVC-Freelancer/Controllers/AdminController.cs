using Microsoft.AspNetCore.Authorization;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationDbContext db, UserManager<AppUser> um, RoleManager<IdentityRole> roleManager) : base(um)
        {
            this.db = db;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult ListAllRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new()
                {
                    Name = model.RoleName
                };
                var result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListAllRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        //[Authorize(Roles = "Admin")]
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
                                      Id = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      //Role = string.Join(",", p.RoleNames)
                                  });
            return View(usersWithRoles);
        }

        public IActionResult IsDisabled(string id, AppUser usr)
        {
            var userFd = db.AppUser.FirstOrDefault(r => r.Id == id); //Търсене на потребител по айди
            usr.IsDisabled = userFd.IsDisabled;
            userFd.IsDisabled = true;
            db.Update(userFd);
             db.SaveChanges();
            return RedirectToAction("UsersList");
        }
    }
}
