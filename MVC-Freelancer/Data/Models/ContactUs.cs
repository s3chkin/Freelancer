namespace MVC_Freelancer.Data.Models
{
    public class ContactUs
    {
        public ContactUs()
        {
            this.Jobs = new HashSet<Job>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; } //zaglavie
        public string Message { get; set; }
        //public int JobId { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }


    }
}
