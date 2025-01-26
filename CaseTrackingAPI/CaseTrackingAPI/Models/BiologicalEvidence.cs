namespace CaseTrackingAPI.Models
{
    public class BiologicalEvidence : Evidence
    {
        public string Type { get; set; } = null!;
        public string Specification { get; set; } = null!;
        public string? RetrievalTechnique { get; set; }
    }
}
