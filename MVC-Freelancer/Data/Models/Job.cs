namespace MVC_Freelancer.Data.Models
{
    public class Job
    {
        public Job()
        {
            this.Images = new HashSet<Image>();
            this.Categories = new HashSet<Category>();
            this.ContactUs= new HashSet<ContactUs>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DeadLine { get; set; }
        public string Progress { get; set; }
        public bool? Status { get; set; }
        public int? Rating { get; set; }
        public string WorkType { get; set; }

        //пакети:
        public string PackageName { get; set; }
        public string PacketDescription { get; set; }
        public int DeliveryTime { get; set; }
        public double PacketPrice { get; set; }
        public int Revision { get; set; }
        public string? ExtraInfo { get; set; }


        //за втория пакет
        public string PackageName2 { get; set; }
        public string PacketDescription2 { get; set; }
        public int DeliveryTime2 { get; set; }
        public double PacketPrice2 { get; set; }
        public int Revision2 { get; set; }
        public string? ExtraInfo2 { get; set; }


        //за третия пакет
        public string PackageName3 { get; set; }
        public string PacketDescription3 { get; set; }
        public int DeliveryTime3 { get; set; }
        public double PacketPrice3 { get; set; }
        public int Revision3 { get; set; }
        public string? ExtraInfo3 { get; set; }




        //public string GiverId { get; set; }
        //public virtual AppUser Giver { get; set; }

        //public string WorkerId { get; set; }
        //public virtual AppUser Worker { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public int ContactUsId { get; set; }
        public virtual ICollection<ContactUs> ContactUs { get; set; }
        public List<Comment>CommentState { get; set; }


    }
}
