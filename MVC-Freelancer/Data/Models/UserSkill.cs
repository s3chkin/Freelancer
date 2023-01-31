namespace MVC_Freelancer.Data.Models
{
    public class UserSkill
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public int UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
