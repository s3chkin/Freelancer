namespace MVC_Freelancer.Data.Models
{
    public class JobPackage
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public string? Count { get; set; }
    }
}
