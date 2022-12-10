namespace Freelancer.Data.Models
{
    public class Advertisement
    {
        public string Description { get; set; } // opisanie
        public double Wage { get; set; } //zaplata
        public string Location { get; set; } //lokatsiya
        public TimeSpan TransmissionTime { get; set; }//vreme za predavane
        public TimeSpan Rest { get; set; }//pochivka
        public string Languages { get; set; }
        public string JobTitle { get; set; }
        public string Category{ get; set; }
    }
}
