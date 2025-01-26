namespace CaseTrackingAPI.Models
{
    public class Victim : Person
    {
        public string Location { get; set; } = null!;
        public DateTime Time { get; set; }
        public string? Method { get; set; }
        public string Condition { get; set; } = null!;
    }
}
