using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;
using MVC_Freelancer.Services;
using System.Diagnostics;

namespace MVC_Freelancer.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        //private readonly object shortStringService;
        private string[] allowedExtention = new[] { "png", "jpg", "jpeg" };
        private string[] allowedExtention2 = new[] { "png", "jpg", "jpeg", "zip", "txt", "exe", "cs", "css", "js", "sln", "rar" };



        private readonly ILogger<HomeController> _logger;
        //private readonly IDataBaseSeeder dbSeeder;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, UserManager<AppUser> um/*, IDataBaseSeeder dbSeeder*/) : base(um)
        {
            _logger = logger;
            //this.dbSeeder = dbSeeder;
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;

        }

        public async Task<IActionResult> Index()
        {

            var model = await db.Jobs.Where(j => j.Finished == true)
                .Select(x => new InputJobModel
                {
                    Author = x.Taker,
                    Finished = x.Finished,
                    Name = x.Name,
                    Price = x.Price,
                    Id = x.Id,
                    WorkType = x.WorkType,
                    Status = x.Status,
                    Progress = x.Progress,
                    RatingForTaker = x.RatingForTaker,
                    DeadLine = x.DeadLine,
                    ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //прочитене на снимката от базата данни
                    FileURL = $"/file/{x.Files.FirstOrDefault().Id}.{x.Files.FirstOrDefault().Extention}", //прочитене на файла от базата данни
                }
             ).ToListAsync();
            return View(model);
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