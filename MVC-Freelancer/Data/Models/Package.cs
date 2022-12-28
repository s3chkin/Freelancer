namespace MVC_Freelancer.Data.Models
{
    public class Package
    {

        public int Id { get; set; }
        public string PacketName1 { get; set; }
        public string PacketDescription1 { get; set; }
        public int DeliveryTime1 { get; set; }
        public double Price1{ get; set; }
        public int Revision1{ get; set; }

        public string PacketName2 { get; set; }
        public string PacketDescription2 { get; set; }
        public int DeliveryTime2 { get; set; }
        public double Price2 { get; set; }
        public int Revision2 { get; set; }


        public string PacketName3 { get; set; }
        public string PacketDescription3 { get; set; }
        public int DeliveryTime3 { get; set; }
        public double Price3 { get; set; }
        public int Revision3 { get; set;}

        public virtual Job Job{ get; set; }


    }
}
