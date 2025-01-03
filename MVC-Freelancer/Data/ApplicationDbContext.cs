﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Freelancer.Data.Models;
using System.Diagnostics;
using System.Reflection.Emit;

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
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Models.File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) //първичен ключ и описание на връзките
        {
            builder.Entity<Job>()
            .HasOne<AppUser>(j => j.Giver)
            .WithMany(g => g.JobsGiven)
            .HasForeignKey(j => j.GiverId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Job>()
                     .HasOne<AppUser>(j => j.Taker)
                     .WithMany(g => g.JobsTaken)
                     .HasForeignKey(j => j.TakerId)
                     .OnDelete(DeleteBehavior.NoAction)
                     .IsRequired(false);
            base.OnModelCreating(builder);
        }

    }
}