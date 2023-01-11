using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Models
{
    public class InputJobModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsDeleted { get; set; }
        public string Progress { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
        public string? Type { get; set; } // търси / предлага
        public string CategoryName { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<InputJobNeedModel> Needs { get; set; }
        public string ImgURL { get; set; }

    }
}
