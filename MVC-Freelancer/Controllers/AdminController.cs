//using AspNetCore;
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


        public IActionResult LoginError()//ако акаунтът на потребителя е блокиран от администратора, ще се препрати към този екшън
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult UsersList(string id, UserViewModel model)
        {
            var userFd = db.AppUser.FirstOrDefault(r => r.Id == id);
            var usersWithRoles = (from user in db.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      IsDisabled = model.IsDisabled
                                  }).ToList().Select(p => new UserViewModel()
                                  {
                                      Id = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      IsDisabled = p.IsDisabled,
                                  });
            return View(usersWithRoles);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Disable(string id, UserViewModel model, bool isDsbld)
        {

            var userFd = db.AppUser.FirstOrDefault(r => r.Id == id); //Търсене на потребител по айди
            if (userFd.IsDisabled == false)
            {
                userFd.IsDisabled = true;
            }
            else
            {
                userFd.IsDisabled = false;
            }

            //model.IsDisabled = true;
            //model.IsDisabled = userFd.IsDisabled;
            db.Update(userFd);
            db.SaveChanges();
            return RedirectToAction("UsersList");
        }

        public IActionResult DeleteMsg(int id)
        {
            var msg = db.ContactUs.Where(s => s.Id == id).FirstOrDefault(); //търсене
            db.ContactUs.Remove(msg);
            db.SaveChanges();
            return this.RedirectToAction("messages");
        }
    }
}
