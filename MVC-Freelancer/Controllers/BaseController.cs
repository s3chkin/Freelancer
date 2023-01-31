using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly UserManager<AppUser> um;

        public BaseController(UserManager<AppUser> um)
        {
            this.um = um;
        }

        protected string? GetCurrentUserId()
        {         
            return um.GetUserId(HttpContext.User);         
        }



    }
}
