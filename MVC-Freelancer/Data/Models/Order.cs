namespace MVC_Freelancer.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.Jobs = new HashSet<Job>();
            //this.Images= new HashSet<Image>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DeadLine { get; set; }
        public string Progress { get; set; }
        public bool? Status { get; set; }
        public double? Rating { get; set; }
        public string WorkType { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        //public virtual ICollection<Image> Images { get; set; }

    }
}
