using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;

namespace MVC_Freelancer.Controllers
{
    public class RequestController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        private string[] allowedExtention = new[] { "png", "jpg", "jpeg" };
        private string[] allowedExtention2 = new[] { "png", "jpg", "jpeg", "zip", "txt", "exe", "cs", "css", "js", "sln", "rar" };
        public RequestController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, UserManager<AppUser> um) : base(um)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            //
            var categories = db.Categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            InputRequestModel model = new InputRequestModel
            {
                Categories = categories
            };
            return View(model);
        }

     
        
        public IActionResult ById(int id)
        {
            var model = db.Jobs.Where(x => id == x.Id).Select(x => new InputJobModel
            {
                //otlyavo modeli otdyasno bazatadanni
                Name = x.Name,
                //CategoryName = x.Categories.Name,
                DeadLine = x.DeadLine,
                Price = x.Price,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Progress = x.Progress,

                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}",

                PackageName = x.PackageName,
                DeliveryTime = x.DeliveryTime,
                PacketDescription = x.PacketDescription,
                PacketPrice = x.PacketPrice,
                Revision = x.Revision,
                ExtraInfo = x.ExtraInfo,

                PackageName2 = x.PackageName2,
                DeliveryTime2 = x.DeliveryTime2,
                PacketDescription2 = x.PacketDescription2,
                PacketPrice2 = x.PacketPrice2,
                Revision2 = x.Revision2,
                ExtraInfo2 = x.ExtraInfo2,

                PackageName3 = x.PackageName3,
                DeliveryTime3 = x.DeliveryTime3,
                PacketDescription3 = x.PacketDescription3,
                PacketPrice3 = x.PacketPrice3,
                Revision3 = x.Revision3,
                ExtraInfo3 = x.ExtraInfo3,
            }).FirstOrDefault();
            //var category = db.Categories.Where(x => model.CategoryId == x.Id).FirstOrDefault();
            return this.View(model);
        }


        public IActionResult Requests()
        {
            var model = db.Jobs.Where(x => x.WorkType == "Търся" && x.Status == true && x.DeadLine > DateTime.Today && x.TakerId == null).Select(x => new InputJobModel
            {
                Name = x.Name,
                Price = x.Price,
                Id = x.Id,
                FileURL = $"/file/{x.Files.FirstOrDefault().Id}.{x.Files.FirstOrDefault().Extention}",
                Status = x.Status,
                WorkType = x.WorkType,
                Finished = x.Finished,
                Progress = x.Progress,
                DeadLine = x.DeadLine,
                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //прочитене на снимката от базата данни
                Author = x.Giver,
                TakerId = x.TakerId
            }).ToList();

            return View(model);
        }

        public IActionResult Accept(int id)
        {
            var jobFd = db.Jobs.FirstOrDefault(r => r.Id == id);
            jobFd.Finished = true;
            db.Update(jobFd);
            db.SaveChanges();
            return Redirect("Requests");
        }

        //Търсачка
        public async Task<IActionResult> Search(string querry)
        {
            var jobsFd = db.Jobs.Where(x => x.Name.Contains(querry)).Select(x => new InputJobModel
            {
                Name = x.Name,
                Price = x.Price,
                Id = x.Id,
                Status = x.Status,
                WorkType = x.WorkType,
                Finished = x.Finished,
                DeadLine = x.DeadLine,
                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //прочитене на снимката от базата данни
                Author = x.Giver
            }).ToList();

            ViewData["Search"] = querry;
            return View("Requests", jobsFd);
        }
    }
}
