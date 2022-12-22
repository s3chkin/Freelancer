namespace MVC_Freelancer.Data.Models
{
    public class Need
    {
        public Need()
        {
            this.Jobs = new HashSet<JobNeed>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<JobNeed> Jobs { get; set; }

    }
}
