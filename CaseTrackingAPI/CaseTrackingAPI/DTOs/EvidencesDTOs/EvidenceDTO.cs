namespace CaseTrackingAPI.DTOs.EvidencesDTOs
{
    public class EvidenceDTO
    {
        public string Name { get; set; } = null!;
        public DateTime RetrievalTime { get; set; }
        public string? Location { get; set; }
        public string Attachment { get; set; } = null!;
        public int PersonId { get; set; }
    }

    public class UpdateEvidenceDTO
    {
        public string? Name { get; set; }
        public DateTime? RetrievalTime { get; set; }
        public string? Location { get; set; }
        public string? Attachment { get; set; }
        public int? PersonId { get; set; }
    }
}
