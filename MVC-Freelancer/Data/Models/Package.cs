using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Freelancer.Data.Models
{
    public class Package
    {
        //междинна таблица
        public Package()
        {
            this.JobPackages = new HashSet<JobPackage>();
        }
        public int Id { get; set; }
        public string PackageName { get; set; }
        public string PacketDescription { get; set; }
        public int DeliveryTime { get; set; }
        public double Price { get; set; }
        public int Revision { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<JobPackage> JobPackages { get; set; }




    }
}
