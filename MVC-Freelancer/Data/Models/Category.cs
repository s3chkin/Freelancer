namespace MVC_Freelancer.Data.Models
{
    public class Category
    {
        public Category()
        {
            // this.Jobs = new HashSet<Job>();

            CategoryJobs = new HashSet<JobCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        //   public virtual ICollection<Job> Jobs { get; set; } //колекция(списък) от обяви, осъществяване на връзка между таблиците 
        public virtual ICollection<JobCategory> CategoryJobs { get; set; }

    }
}
