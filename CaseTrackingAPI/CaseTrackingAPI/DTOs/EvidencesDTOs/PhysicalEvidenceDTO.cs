namespace CaseTrackingAPI.DTOs.EvidencesDTOs
{
    public class PhysicalEvidenceDTO : EvidenceDTO
    {
        public bool UsedInCrime { get; set; }
        public string? DangerLevel { get; set; }
        public string Classification { get; set; } = null!;
        public bool RequiresExamination { get; set; }
        public bool ContainsBiologicalTraces { get; set; }
    }

    public class UpdatePhysicalEvidenceDTO : UpdateEvidenceDTO
    {
        public bool? UsedInCrime { get; set; }
        public string? DangerLevel { get; set; }
        public string? Classification { get; set; }
        public bool? RequiresExamination { get; set; }
        public bool? ContainsBiologicalTraces { get; set; }
    }
}
