using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Models
{
    public class InputRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Sum { get; set; }
        public DateTime DeadLine { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

    }
}
