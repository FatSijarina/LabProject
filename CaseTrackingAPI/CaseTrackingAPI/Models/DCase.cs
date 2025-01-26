namespace CaseTrackingAPI.Models
{
    public class DCase
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "Opened";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }

        /*public ICollection<Viktima>? Viktimat { get; set; }
        public ICollection<Deshmitari>? Deshmitaret { get; set; }
        public ICollection<iDyshuari>? TeDyshuarit { get; set; }
*/
        public ICollection<DTask>? CaseTasks { get; set; }
        public ICollection<DFile>? Files { get; set; }
    }
}