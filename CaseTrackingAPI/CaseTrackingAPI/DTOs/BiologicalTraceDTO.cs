namespace CaseTrackingAPI.DTOs
{
    public class BiologicalTraceDTO
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int PersonId { get; set; }
        public string Specification { get; set; } = null!;
    }

    public class UpdateBiologicalTraceDTO
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? PersonId { get; set; }
        public string? Specification { get; set; }
    }
}
