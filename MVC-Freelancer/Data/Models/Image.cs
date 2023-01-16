namespace MVC_Freelancer.Data.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; } //imeto na snimkata
        public string Extention { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        

        
    }
}
