using CaseTrackingAPI.Models;

namespace CaseTrackingAPI.DTOs
{
    public class GetCasesDetailsDTO
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "Opened";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
    }
    public class GetCaseDTO
    {
        public string? ImageUrl { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "Opened";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        /*public ICollection<ViktimaDTO>? Viktimat { get; set; }
        public ICollection<DeshmitariDTO>? Deshmitaret { get; set; }
        public ICollection<iDyshuariDTO>? TeDyshuarit { get; set; }*/
        public ICollection<CaseTask>? CaseTasks { get; set; }
        public ICollection<DFile>? Files { get; set; }
    }

    public class AddCaseDTO
    {
        public string? ImageUrl { get; set; }
        public string Identifier { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "Opened";
        public string? Details { get; set; }
        public DateTime DateOpened { get; set; } = DateTime.Now;
    }

    public class UpdateCaseDTO
    {
        public string? ImageUrl { get; set; }
        public string? Identifier { get; set; } = null!;
        public string? Title { get; set; } = null!;
        public string? Status { get; set; } = "Opened";
        public string? Details { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}