using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Controllers
{
    public class PortfolioController : BaseController
    {
        public PortfolioController( UserManager<AppUser> um) : base(um)
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio() 
        { 
            return View();
        }
    }
}
