using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Models
{
    public class InputJobModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DeadLine { get; set; }
        public string Progress { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImgURL { get; set; }
        public bool? Status { get; set; }
        public int? Rating { get; set; }


        //пакети:
        public string PackageName { get; set; }
        public string PacketDescription { get; set; }
        public int DeliveryTime { get; set; }
        public double PacketPrice { get; set; }
        public int Revision { get; set; }
        public string? ExtraInfo { get; set; }


        //за втора таблица
        public string PackageName2 { get; set; }
        public string PacketDescription2 { get; set; }
        public int DeliveryTime2 { get; set; }
        public double PacketPrice2 { get; set; }
        public int Revision2 { get; set; }
        public string? ExtraInfo2 { get; set; }


        //за трета таблица
        public string PackageName3 { get; set; }
        public string PacketDescription3 { get; set; }
        public int DeliveryTime3 { get; set; }
        public double PacketPrice3 { get; set; }
        public int Revision3 { get; set; }
        public string? ExtraInfo3 { get; set; }


        public List<SelectListItem> Categories { get; set; }


    }
}
