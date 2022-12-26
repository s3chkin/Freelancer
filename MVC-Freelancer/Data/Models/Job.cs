﻿namespace MVC_Freelancer.Data.Models
{
    public class Job
    {
        public Job()
        {
            this.Images = new HashSet<Image>();
            this.Needs = new HashSet<JobNeed>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsDeleted { get; set; }
        public string Progress { get; set; }
        //public string GiverId { get; set; }
        //public virtual AppUser Giver { get; set; }

        //public string WorkerId { get; set; }
        //public virtual AppUser Worker { get; set; }
        public int CategoryId { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<JobNeed> Needs { get; set; }
    }
}