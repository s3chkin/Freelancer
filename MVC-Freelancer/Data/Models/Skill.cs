namespace MVC_Freelancer.Data.Models
{
    public class Skill //за юзъра
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserSkill> Users { get; set; }
    }
}
