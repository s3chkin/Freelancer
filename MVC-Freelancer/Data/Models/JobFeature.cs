namespace MVC_Freelancer.Data.Models
{
    public class JobFeature
    {//todo composite key
        public int FeatureId { get; set; }
        public virtual Feature Feature{ get; set; }
        public int JobId { get; set; }
        public virtual Job Job{ get; set; }



    }
}
