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
    }
}
