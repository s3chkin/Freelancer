using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Freelancer.Data.Models
{
    public class Job
    {
        public Job()
        {
            this.JobCategories = new HashSet<JobCategory>();

            JobFeatures = new HashSet<JobFeature>();
            JobRatings = new HashSet<UserRating>();
        }
        public string Image { get; set; } //    www.img1.jpg
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }

        [Range(0, 100)]
        public int Progress { get; set; }
        public bool? Status { get; set; } //false=pause, 

        public string DescriptionBasic { get; set; }
        public double PriceBasic { get; set; }
       
        public string DescriptionGold { get; set; }
        public double PriceGold { get; set; }

        public string DescriptionDiamond { get; set; }
        public double PriceDiamond { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string GiverId { get; set; }
        public virtual AppUser Giver { get; set; }


        [ForeignKey(nameof(AppUser))]
        public string TakerId { get; set; }
        public virtual AppUser Taker { get; set; }





        ////пакети:
        //public string PackageName { get; set; }
        //public string PacketDescription { get; set; }
        //public int DeliveryTime { get; set; }
        //public double PacketPrice { get; set; }
        //public int Revision { get; set; }
        //public string? ExtraInfo { get; set; }


        ////за втория пакет
        //public string PackageName2 { get; set; }
        //public string PacketDescription2 { get; set; }
        //public int DeliveryTime2 { get; set; }
        //public double PacketPrice2 { get; set; }
        //public int Revision2 { get; set; }
        //public string? ExtraInfo2 { get; set; }


        ////за третия пакет
        //public string PackageName3 { get; set; }
        //public string PacketDescription3 { get; set; }
        //public int DeliveryTime3 { get; set; }
        //public double PacketPrice3 { get; set; }
        //public int Revision3 { get; set; }
        //public string? ExtraInfo3 { get; set; }




        ////public string GiverId { get; set; }
        ////public virtual AppUser Giver { get; set; }

        ////public string WorkerId { get; set; }
        ////public virtual AppUser Worker { get; set; }
        //public int CategoryId { get; set; }
        //public List<Comment> CommentState { get; set; }



        public virtual ICollection<UserRating> JobRatings { get; set; }
        public virtual ICollection<JobFeature> JobFeatures { get; set; }
        public virtual ICollection<JobCategory> JobCategories { get; set; }

    }
}
