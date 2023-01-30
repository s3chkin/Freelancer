using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }       
        public DbSet<Feature> Features { get; set; }
        public DbSet<Opinion> Opinions{ get; set; }
        public DbSet<Opinion>  ContactUs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobFeature> GetJobFeatures { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<UserSkill> UserSkills{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserSkill>().HasKey(x => new { x.SkillId, x.AppUserId });// kompoziten klyuch
            //builder.Entity<JobCategory>().HasKey(x => new { x.SkillId, x.AppUserId });// kompoziten klyuch
            
            
            
            
            
            base.OnModelCreating(builder);
        }
    }

    
}