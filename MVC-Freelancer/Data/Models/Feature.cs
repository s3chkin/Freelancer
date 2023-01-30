using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_Freelancer.Data.Models
{
    public class Feature
    {
        public Feature()
        {
            FeatureJobs = new HashSet<JobFeature>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Prime { get; set; }
        public string Description{ get; set; }

        public virtual ICollection<JobFeature> FeatureJobs { get; set; }
    
    }
}
