using Microsoft.AspNetCore.Identity;

namespace MVC_Freelancer.Data.Models
{
    public class Role : IdentityRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
