﻿using Microsoft.AspNetCore.Identity;

namespace MVC_Freelancer.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            //userLanguages = new HashSet<LanguageUser>();
            //JobsGiven = new HashSet<Job>();
           
            Roles = new HashSet<IdentityUserRole<string>>();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
            this.Id = Guid.NewGuid().ToString();
            JobsGiven = new HashSet<Job>();
            JobsTaken= new HashSet<Job>();

        }
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        //public string Skills { get; set; }
        public string FirstName { get; set; }
        public bool IsDisabled { get; set; }
        //public virtual ICollection<Job> JobsGiven { get; set; }

        public virtual  ICollection<Job> JobsGiven { get; set; }
        public virtual  ICollection<Job> JobsTaken { get; set; }

    }
}
