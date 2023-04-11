using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;
using Recipes.Services;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Mail;
using File = MVC_Freelancer.Data.Models.File;

namespace MVC_Freelancer.Controllers
{
    public class JobController : BaseController
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        //private readonly object shortStringService;
        private string[] allowedExtention = new[] { "png", "jpg", "jpeg" };
        private string[] allowedExtention2 = new[] { "png", "jpg", "jpeg", "zip", "txt", "exe", "cs", "css", "js", "sln", "rar" };

        public JobController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment/*, IShortStringService shortStringService*/, UserManager<AppUser> userManager) : base(userManager)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
            //this.shortStringService = shortStringService; //injektirane
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = db.Jobs.Where(x => x.WorkType == "Предлагам" && x.Status == true && x.DeadLine > DateTime.Today && x.TakerId == null).Select(x => new InputJobModel
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(InputJobModel model)
        {
            //Добавяне на 1 обява в базата данни
            var job = new Job
            {
                Name = model.Name,
                DeadLine = model.DeadLine,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Description = model.Description,
                //Progress = model.Progress,
                Status = model.Status,
                WorkType = model.WorkType,
                RatingForTaker = model.RatingForTaker,


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
                Giver = await GetCurrentUserAsync()

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
            await db.Jobs.AddAsync(job);
            await db.SaveChangesAsync();

            return this.RedirectToAction("Index");
        }

        public IActionResult ById(int id)
        {
            var model = db.Jobs.Where(x => id == x.Id).Select(x => new InputJobModel
            {
                Id = x.Id,
                Author = x.Giver,
                //otlyavo modeli otdyasno bazata danni
                Name = x.Name,
                //CategoryName = x.Categories.Name,
                DeadLine = x.DeadLine,
                Price = x.Price,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Progress = x.Progress,
                Finished = x.Finished,
                Status = x.Status,
                RatingForTaker = x.RatingForTaker,
                FileURL = $"/file/{x.Files.FirstOrDefault().Id}.{x.Files.FirstOrDefault().Extention}",
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
                WorkType = job.WorkType,

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
            job.WorkType = model.WorkType;


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
            return RedirectToAction("MyJobs");

        }
        public IActionResult DeleteMsg(int id)
        {
            var msg = db.ContactUs.Where(s => s.Id == id).FirstOrDefault(); //търсене
            db.ContactUs.Remove(msg);
            db.SaveChanges();
            return this.RedirectToAction("messages");
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
        [Authorize]
        public IActionResult Contacts()
        {
            return this.View();
        }
        [HttpPost]
        [Authorize]
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

            return RedirectToAction("Contacts");

        }
        public IActionResult Messages()
        {
            var msg = db.ContactUs.Select(x => new InputSendMailModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Subject = x.Subject,
                Message = x.Message,
            }).ToList();
            return View(msg);
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
            return RedirectToAction("MyJobs");

        }
        [Authorize]
        public async Task<IActionResult> Accept(int id)
        {
            string myId = (await GetCurrentUserAsync()).Id; //моето айди
            var jobFd = db.Jobs.FirstOrDefault(r => r.Id == id); //Търсене на обява по айди
            jobFd.TakerId = myId;
            db.Update(jobFd);
            await db.SaveChangesAsync();
            return RedirectToAction("Orders");
        }



        //Refuse
        public async Task<IActionResult> Refuse(int id)
        {
            //string myId = (await GetCurrentUserAsync()).Id;
            var jobFd = db.Jobs.FirstOrDefault(j => j.Id == id);
            jobFd.TakerId = null;
            db.Update(jobFd);
            await db.SaveChangesAsync();
            return RedirectToAction("Orders");
        }

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
            return View("Index", jobsFd);
        }

        public async Task<IActionResult> MyJobs()
        {
            string myId = (await GetCurrentUserAsync()).Id;
            var model = await db.Jobs.Where(j => j.GiverId == myId)
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
                    FileURL = $"/file/{x.Files.FirstOrDefault().Id}.{x.Files.FirstOrDefault().Extention}",
                }
             ).ToListAsync();
            return View(model);
        }

        public IActionResult GetJob(int id)
        {
            //Job jobFd = db.Jobs.FirstOrDefault(r => r.Id == id);

            var model = db.Jobs.Where(x => id == x.Id).Select(x => new InputJobModel
            {
                //otlyavo modeli otdyasno bazatadanni
                Name = x.Name,
                Price = x.Price,
                Id = x.Id,
                Status = x.Status,
                Progress = x.Progress,
                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //прочитене на снимката от базата данни
                FileURL = $"/file/{x.Files.FirstOrDefault().Id}.{x.Files.FirstOrDefault().Extention}",
            }
             ).ToList();
            db.SaveChanges();
            //return RedirectToAction("Index");
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Orders()
        {
            string myId = (await GetCurrentUserAsync()).Id;
            var model = await db.Jobs.Where(j => j.TakerId == myId).Select(x => new InputJobModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Status = x.Status,
                WorkType = x.WorkType,
                Finished = x.Finished,
                Progress = x.Progress,
                RatingForGiver = x.RatingForGiver,
                DeadLine = x.DeadLine,
                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //прочитене на снимката от базата данни
                FileURL = $"/file/{x.Files.FirstOrDefault().Id}.{x.Files.FirstOrDefault().Extention}",
            }).ToListAsync();

            return View(model);
        }

        //качване на файл 
        [HttpGet]
        public IActionResult SendFiles(int id)
        {
            var job = db.Jobs.Where(s => s.Id == id).FirstOrDefault();
            //id = job.Id;
            return View();
        }

        [HttpPost]
        public IActionResult SendFiles(int id, InputJobModel model)
        {
            var jobFd = db.Jobs.Where(s => s.Id == id).FirstOrDefault();
            jobFd.Finished = true;
            var extention = Path.GetExtension(model.File.FileName).TrimStart('.');
            var file2 = new File
            {
                Extention = extention
            };
            string path = $"{webHostEnvironment.WebRootPath}/file/{file2.Id}.{extention}";

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                model.File.CopyTo(fs);
            }

            jobFd.Files.Add(file2);
            db.Update(jobFd);
            db.SaveChanges();
            return RedirectToAction("Orders");
        }

        [Authorize]
        public async Task<IActionResult> Finished(int id)
        {
            var jobFd = db.Jobs.FirstOrDefault(r => r.Id == id); //Търсене на обява по айди
            jobFd.Finished = true;
            db.Update(jobFd);
            await db.SaveChangesAsync();
            return RedirectToAction("Orders");
        }

        [HttpPost]
        public IActionResult Progress(int newProgress, int id)
        {
            var jobFd = db.Jobs.FirstOrDefault(r => r.Id == id);
            jobFd.Progress = newProgress;
            db.Jobs.Add(jobFd);
            db.Update(jobFd);
            db.SaveChanges();
            return RedirectToAction("Orders");
        }

        [HttpPost]
        public IActionResult RatingForTaker(int rating, int id)
        {
            var jobFd = db.Jobs.FirstOrDefault(r => r.Id == id);
            jobFd.RatingForTaker = rating;
            db.Jobs.Add(jobFd);
            db.Update(jobFd);
            db.SaveChanges();
            return RedirectToAction("MyJobs");
        }
        [HttpPost]
        public IActionResult RatingForGiver(int rating, int id)
        {
            var jobFd = db.Jobs.FirstOrDefault(r => r.Id == id);
            jobFd.RatingForGiver = rating;
            db.Jobs.Add(jobFd);
            db.Update(jobFd);
            db.SaveChanges();
            return RedirectToAction("Orders");
        }







        


    }
}

