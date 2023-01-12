using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<JobNeed> JobNeeds { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<ContactUs>  ContactUs { get; set; }
        public DbSet<UserSkill> UserSkills{ get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}