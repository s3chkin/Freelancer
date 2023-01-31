using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_Freelancer.Data.Models
{
    public class Request
    {
        public Request()
        {
            this.Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Sum { get; set; }
        public string Description{ get; set; }
        public DateTime DeadLine { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
