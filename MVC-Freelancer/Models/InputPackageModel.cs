namespace MVC_Freelancer.Models
{
    public class InputPackageModel
    {
        public int Id { get; set; }
        public string PackageName1 { get; set; }
        public string PackageName2 { get; set; }
        public string PackageName3 { get; set; }

        public string PacketDescription1 { get; set; }
        public int DeliveryTime1 { get; set; }
        public double Price1 { get; set; }
        public int Revision1 { get; set; }

        public string PacketDescription2 { get; set; }
        public int DeliveryTime2 { get; set; }
        public double Price2 { get; set; }
        public int Revision2 { get; set; }


        public string PacketDescription3 { get; set; }
        public int DeliveryTime3 { get; set; }
        public double Price3 { get; set; }
        public int Revision3 { get; set; }
    }
}
