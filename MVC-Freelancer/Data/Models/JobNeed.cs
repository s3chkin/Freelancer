namespace MVC_Freelancer.Data.Models
{
    public class JobNeed
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public virtual Job Job { get; set; }
        public int NeedId { get; set; }
        public virtual Need Need { get; set; }
        public string Description { get; set; }
    }
}
