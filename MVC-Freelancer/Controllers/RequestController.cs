using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Models;

namespace MVC_Freelancer.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        private string[] allowedExtention = new[] { "png", "jpg", "jpeg" };
        public RequestController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var model = db.Requests.Select(x => new InputRequestModel
            {
                Id = x.Id,
                Sum = x.Sum,
                DeadLine = x.DeadLine,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,

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
            InputRequestModel model = new InputRequestModel
            {
                Categories = categories
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(InputRequestModel model)
        {
            var request = new Request
            {

                Sum = model.Sum,
                DeadLine = model.DeadLine,
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,

            };

            db.Requests.Add(request);
            db.SaveChanges();

            return this.RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var request = db.Requests.Where(s => s.Id == id).FirstOrDefault(); //търсене
            db.Requests.Remove(request);
            db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var request = db.Requests.Where(s => s.Id == id).FirstOrDefault();

            var model = new InputRequestModel
            {
                Id = request.Id,
                Title = request.Title,
                DeadLine = request.DeadLine,
                Description = request.Description,
                Sum = request.Sum,
                CategoryId = request.CategoryId,
                //Categories = (List<SelectListItem>)request.Categories,

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
        public IActionResult Edit(int id, InputRequestModel model) //update
        {
            var request = db.Requests.Where(s => s.Id == model.Id).FirstOrDefault(); //търсене
            request.Id = model.Id;
            request.Title = model.Title;
            request.DeadLine = model.DeadLine;
            request.Description = model.Description;
            request.Sum = model.Sum;
            request.CategoryId = model.CategoryId;

            db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        

        public IActionResult Requests()
        {
            var model = db.Jobs.Select(x => new InputJobModel
            {
                Name = x.Name,
                Price = x.Price,
                Id = x.Id,
                Status = x.Status,
                WorkType = x.WorkType,
                ImgURL = $"/img/{x.Images.FirstOrDefault().Id}.{x.Images.FirstOrDefault().Extention}", //прочитене на снимката от базата данни
            }
            ).ToList();
            return View(model);
        }
    }
}
