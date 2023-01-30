namespace MVC_Freelancer.Data.Models
{
    public class Skill //за юзъра
    {
        public Skill()
        {
            SkillUsers = new HashSet<UserSkill>();
        } 
        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserSkill> SkillUsers { get; set; }
    }
}
