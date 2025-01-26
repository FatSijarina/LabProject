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

        public ICollection<Victim>? Victims { get; set; }
        public ICollection<Witness>? Witnesses { get; set; }
        public ICollection<Suspect>? Suspects { get; set; }

        public ICollection<DTask>? CaseTasks { get; set; }
        public ICollection<DFile>? Files { get; set; }
    }
}