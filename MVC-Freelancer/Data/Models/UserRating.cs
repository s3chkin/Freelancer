namespace MVC_Freelancer.Data.Models
{
    public class UserRating
    {//todo composite key
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public Grade Grade { get; set; }
    }
}
