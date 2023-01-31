//using MessagePack;

using System.ComponentModel.DataAnnotations;

namespace MVC_Freelancer.Data.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentUser { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentCintent { get; set; }
        public bool CommentState { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
