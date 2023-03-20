using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;
using MVC_Freelancer.Services;
using System.Diagnostics;

namespace MVC_Freelancer.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataBaseSeeder dbSeeder;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> um, IDataBaseSeeder dbSeeder) : base(um)
        {
            _logger = logger;
            this.dbSeeder = dbSeeder;
         
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}