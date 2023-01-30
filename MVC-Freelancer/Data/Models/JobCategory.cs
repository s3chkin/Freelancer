namespace MVC_Freelancer.Data.Models
{
    public class JobCategory
    {//todo composite key
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
