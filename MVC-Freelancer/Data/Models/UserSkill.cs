namespace MVC_Freelancer.Data.Models
{
    public class UserSkill
    {//todo komposite
   
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
