using Microsoft.AspNetCore.Mvc;

namespace MVC_Freelancer.Controllers
{
    public class PortfolioController : Controller
    {
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
