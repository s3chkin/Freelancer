namespace MVC_Freelancer.Data.Models
{
    public class Opinion
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; } //zaglavie
        public string Message { get; set; }    
    }
}
