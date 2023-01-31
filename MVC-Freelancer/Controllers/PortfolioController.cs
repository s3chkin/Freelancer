using Microsoft.AspNetCore.Mvc;

namespace MVC_Freelancer.Controllers
{
    public class PortfolioController : BaseController
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
