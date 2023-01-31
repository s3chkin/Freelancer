namespace MVC_Freelancer.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Jobs = new HashSet<Job>();
            this.Requests = new HashSet<Request>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Job> Jobs { get; set; } //колекция(списък) от обяви, осъществяване на връзка между таблиците 
        public virtual ICollection<Request> Requests  { get; set; } //колекция(списък) от обяви, осъществяване на връзка между таблиците 

    }
}
