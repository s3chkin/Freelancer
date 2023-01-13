namespace MVC_Freelancer.Models
{
    public class InputJobPackageModel
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public string PacketDescription { get; set; }
        public int DeliveryTime { get; set; }
        public double Price { get; set; }
        public int Revision { get; set; }
        public string? Name { get; set; }
        public string? Count { get; set; }
    }
}
