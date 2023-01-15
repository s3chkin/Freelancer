using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;
using System.Net;
using System.Net.Mail;

namespace MVC_Freelancer.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        private string[] allowedExtention = new[] { "png", "jpg", "jpeg" };

        public JobController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var model = db.Jobs.Select(x => new InputJobModel
            {
                Name = x.Name,
                Price = x.Price,
                Id = x.Id,
                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //четене на снимката от базата данни
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
            //foreach (var item in model.Needs)
            //{
            //    var need = db.Needs.FirstOrDefault(x => item.Name == x.Name);
            //    if (need == null)
            //    {
            //        need = new Need
            //        {
            //            Name = item.Name,
            //        };
            //    }

            //    job.Needs.Add(new JobNeed
            //    {
            //        Need = need,
            //        Description = item.Description
            //    });
            //}
            db.Jobs.Add(job);
            db.SaveChanges();

            return this.Redirect("/");
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
                Categories = (List<SelectListItem>)job.Categories,
            };
            return this.View(model);
        }
        [HttpPost]
        public IActionResult Edit(InputJobModel model) //update
        {
            var job = db.Jobs.Where(s => s.Id == model.Id).FirstOrDefault(); //търсене
            job.Id = model.Id;
            job.Name = model.Name;
            job.DeadLine = model.DeadLine;
            job.Description = model.Description;
            job.Price = model.Price;
            job.Categories = (ICollection<Category>)model.Categories;
            //job.Images = (ICollection<Image>)model.Image;
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
    }
}

