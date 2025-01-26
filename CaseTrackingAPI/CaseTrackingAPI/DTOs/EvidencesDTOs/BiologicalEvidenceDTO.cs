namespace CaseTrackingAPI.DTOs.EvidencesDTOs
{
    public class BiologicalEvidenceDTO : EvidenceDTO
    {
        public string Type { get; set; } = null!;
        public string Specification { get; set; } = null!;
        public string? RetrievalTechnique { get; set; }
    }

    public class UpdateBiologicalEvidenceDTO : UpdateEvidenceDTO
    {
        public string? Type { get; set; }
        public string? Specification { get; set; }
        public string? RetrievalTechnique { get; set; }
    }
}
