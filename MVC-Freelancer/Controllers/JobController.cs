using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;
using Recipes.Services;
using System.Net;
using System.Net.Mail;

namespace MVC_Freelancer.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        //private readonly object shortStringService;
        private string[] allowedExtention = new[] { "png", "jpg", "jpeg" };

        public JobController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment/*, IShortStringService shortStringService*/)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
            //this.shortStringService = shortStringService; //injektirane

        }

        public IActionResult Index()
        {
            var model = db.Jobs.Select(x => new InputJobModel
            {
                Name = x.Name,
                Price = x.Price,
                Id = x.Id,
                Status = x.Status,
                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //прочитене на снимката от базата данни
            }
             ).ToList();
            return View(model);
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
            InputJobModel model = new InputJobModel
            {
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(InputJobModel model)
        {
            //Добавяне на 1 обява в базата данни
            var job = new Job
            {
                Name = model.Name,
                DeadLine = model.DeadLine,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Progress = model.Progress,
                Status = model.Status,
                 WorkType= model.WorkType,


                PackageName = model.PackageName,
                DeliveryTime = model.DeliveryTime,
                PacketDescription = model.PacketDescription,
                PacketPrice = model.PacketPrice,
                Revision = model.Revision,
                ExtraInfo = model.ExtraInfo,

                PackageName2 = model.PackageName2,
                DeliveryTime2 = model.DeliveryTime2,
                PacketDescription2 = model.PacketDescription2,
                PacketPrice2 = model.PacketPrice2,
                Revision2 = model.Revision2,
                ExtraInfo2 = model.ExtraInfo2,

                PackageName3 = model.PackageName3,
                DeliveryTime3 = model.DeliveryTime3,
                PacketDescription3 = model.PacketDescription3,
                PacketPrice3 = model.PacketPrice3,
                Revision3 = model.Revision3,
                ExtraInfo3 = model.ExtraInfo3,

            };
            // от името на прикачения файл получаваме неговото разширение   .png
            var extention = Path.GetExtension(model.Image.FileName).TrimStart('.');
            //създаваме обект, който ще се запише в БД
            var image = new Image
            {
                Extention = extention
            };
            string path = $"{webHostEnvironment.WebRootPath}/img/{image.Id}.{extention}";

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                model.Image.CopyTo(fs);
            }
            job.Images.Add(image);
            db.Jobs.Add(job);
            db.SaveChanges();

            return this.RedirectToAction("Index");
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

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var job = db.Jobs.Where(s => s.Id == id).FirstOrDefault();
            var model = new InputJobModel
            {
                Id = job.Id,
                Name = job.Name,
                DeadLine = job.DeadLine,
                Description = job.Description,
                Price = job.Price,

                DeliveryTime = job.DeliveryTime,
                DeliveryTime2 = job.DeliveryTime2,
                DeliveryTime3 = job.DeliveryTime3,
                PackageName = job.PackageName,
                PackageName2 = job.PackageName2,
                PackageName3 = job.PackageName3,

                PacketDescription = job.Description,
                PacketDescription2 = job.PacketDescription2,
                PacketDescription3 = job.PacketDescription3,

                PacketPrice = job.PacketPrice,
                PacketPrice2 = job.PacketPrice2,
                PacketPrice3 = job.PacketPrice3,

                ExtraInfo = job.ExtraInfo,
                ExtraInfo2 = job.ExtraInfo2,
                ExtraInfo3 = job.ExtraInfo3,

                Revision = job.Revision,
                Revision2 = job.Revision2,
                Revision3 = job.Revision3,
            };
            var categories = db.Categories.Select(x =>
             new SelectListItem
             {
                 Text = x.Name,
                 Value = x.Id.ToString()
             }).ToList();
            model.Categories = categories;
            return this.View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, InputJobModel model) //update
        {
            var job = db.Jobs.Where(s => s.Id == model.Id).FirstOrDefault(); //търсене
            job.Id = model.Id;
            job.Name = model.Name;
            job.DeadLine = model.DeadLine;
            job.Description = model.Description;
            job.Price = model.Price;
            job.CategoryId = model.CategoryId;

            job.PackageName = model.PackageName;
            job.PackageName2 = model.PackageName2;
            job.PackageName3 = model.PackageName3;

            job.PacketDescription = model.PacketDescription;
            job.PacketDescription2 = model.PacketDescription2;
            job.PacketDescription3 = model.PacketDescription3;

            job.PacketPrice = model.PacketPrice;
            job.PacketPrice2 = model.PacketPrice2;
            job.PacketPrice3 = model.PacketPrice3;

            job.Revision = model.Revision;
            job.Revision2 = model.Revision2;
            job.Revision3 = model.Revision3;

            job.ExtraInfo = model.ExtraInfo;
            job.ExtraInfo2 = model.ExtraInfo2;
            job.ExtraInfo3 = model.ExtraInfo3;

            job.DeliveryTime = model.DeliveryTime;
            job.DeliveryTime2 = model.DeliveryTime2;
            job.DeliveryTime3 = model.DeliveryTime3;
            db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var job = db.Jobs.Where(s => s.Id == id).FirstOrDefault(); //търсене
            db.Jobs.Remove(job);
            db.SaveChanges();
            return this.RedirectToAction("Index");
        }
        public IActionResult Services()
        {
            return this.View();
        }
        public IActionResult AboutUs()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Contacts(InputSendMailModel model)
        {
            var contact = new ContactUs
            {
                Name = model.Name,
                Message = model.Message,
                Email = model.Email,
                Subject = model.Subject
            };
            db.ContactUs.Add(contact);
            db.SaveChanges();
            return this.Redirect("Index");
            //return this.View(model);

        }
        public IActionResult Messages()
        {
            var msg = db.ContactUs.Select(x => new InputSendMailModel
            {
                Name = x.Name,
                Email = x.Email,
                Subject = x.Subject,
                Message = x.Message,
            }).ToList();
            return View(msg);
            return this.View();
        }
        public IActionResult AdminPanel()
        {
            var panel = db.ContactUs.Select(x => new InputSendMailModel
            {
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Subject = x.Subject
            }).ToList();
            return View(panel);
        }
        [HttpPost]
        public IActionResult Pause(int id)
        {
            Job jobFd = db.Jobs.FirstOrDefault(r => r.Id == id);
            if (jobFd.Status == true)
            {
                jobFd.Status = false;
            }
            else
            {
                jobFd.Status = true;
            }
            db.Update(jobFd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Rating(int id)
        {
            Job jobFd = db.Jobs.FirstOrDefault(r => r.Id == id);
            jobFd.Rating = 0;
            db.Update(jobFd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

