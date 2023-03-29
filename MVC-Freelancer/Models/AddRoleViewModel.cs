using System.ComponentModel.DataAnnotations;

namespace MVC_Freelancer.Models
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
