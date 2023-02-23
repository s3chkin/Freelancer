using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Controllers
{
    public abstract  class BaseController : Controller
    {
        public BaseController(UserManager<AppUser> um)
        {
            _userManager = um;
        }

        protected UserManager<AppUser> _userManager { get; }

        protected Task<AppUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
