
using Microsoft.Build.Framework;

namespace MVC_Freelancer.Models
{
    public class InputSendMailModel
    {
        public int Id { get; set; } //Айдито е за изтриването на съобщенията
        [Required]
        public string? Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; } //zaglavie
        [Required]
        public string Message { get; set; }
    }
}
