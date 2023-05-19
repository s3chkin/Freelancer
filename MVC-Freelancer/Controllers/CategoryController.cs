using Microsoft.AspNetCore.Mvc;
using MVC_Freelancer.Data.Models;
using MVC_Freelancer.Data;
using MVC_Freelancer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace MVC_Freelancer.Controllers
{
    public class CategoryController : BaseController
    {
        public readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db, UserManager<AppUser> um) : base(um)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var categories = db.Categories.Select(x => new InputCategoryModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Add(InputCategoryModel model)
        {
            var category = new Category
            {
                
                Name =  model.Name
            };
            db.Categories.Add(category);
            db.SaveChanges();
            return this.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = db.Categories.Where(s => s.Id == id).FirstOrDefault();
            var model = new InputCategoryModel
            {
                Id = category.Id,
                Name = category.Name,
            };
            return this.View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, InputCategoryModel model) //update
        {
            var category = db.Categories.Where(s => s.Id == model.Id).FirstOrDefault(); //търсене
            category.Name = model.Name;
            db.SaveChanges();
            return this.RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = db.Categories.Where(s => s.Id == id).FirstOrDefault(); //търсене
            db.Categories.Remove(category);
            db.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}
