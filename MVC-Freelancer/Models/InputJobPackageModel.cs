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
        public string? ExtraInfo { get; set; }

        //за втора таблица
        public string PackageName2 { get; set; }
        public string PacketDescription2 { get; set; }
        public int DeliveryTime2 { get; set; }
        public double Price2 { get; set; }
        public int Revision2 { get; set; }
        public string? ExtraInfo2 { get; set; }


        //за трета таблица
        public string PackageName3 { get; set; }
        public string PacketDescription3 { get; set; }
        public int DeliveryTime3 { get; set; }
        public double Price3 { get; set; }
        public int Revision3 { get; set; }
        public string? ExtraInfo3 { get; set; }

    }
}
