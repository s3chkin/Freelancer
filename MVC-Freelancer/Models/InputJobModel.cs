using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Freelancer.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Freelancer.Models
{
    public class InputJobModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public IFormFile? File { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImgURL { get; set; }
        public string? FileURL { get; set; }
        public bool? Status { get; set; }
        public int? RatingForTaker { get; set; }  // - В това поле се записва рейтингът, изпратен от собственика на обявата за приемащия.
        public int? RatingForGiver { get; set; }  // - В това поле се записва рейтингът, изпратен от приемащия на обявата за собствника й.

       
        [Required]
        public string WorkType { get; set; }
        public bool Finished { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Progress { get; set; }

        public string GiverId { get; set; }
        public string? TakerId { get; set; }
      



        //пакети:
        [Required]
        public string PackageName { get; set; }
        [Required]
        public string PacketDescription { get; set; }
        [Required]
        public int DeliveryTime { get; set; }
        [Required]
        public double PacketPrice { get; set; }
        [Required]
        public int Revision { get; set; }
        public string? ExtraInfo { get; set; }


        //за втори пакет
        [Required]
        public string PackageName2 { get; set; }
        [Required]
        public string PacketDescription2 { get; set; }
        [Required]
        public int DeliveryTime2 { get; set; }
        [Required]
        public double PacketPrice2 { get; set; }
        [Required]
        public int Revision2 { get; set; }
        public string? ExtraInfo2 { get; set; }


        //за трети пакет
        [Required]
        public string PackageName3 { get; set; }
        [Required]
        public string PacketDescription3 { get; set; }
        [Required]
        public int DeliveryTime3 { get; set; }
        [Required]
        public double PacketPrice3 { get; set; }
        [Required]
        public int Revision3 { get; set; }
        public string? ExtraInfo3 { get; set; }


        public List<SelectListItem> Categories { get; set; }
        public AppUser Author { get; internal set; }
    }
}
