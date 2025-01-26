namespace CaseTrackingAPI.Models
{
    public class PhysicalEvidence : Evidence
    {
        public bool UsedInCrime { get; set; }
        public string? DangerLevel { get; set; }
        public string Classification { get; set; } = null!;
        public bool RequiresExamination { get; set; }
        public bool ContainsBiologicalTraces { get; set; }
    }

}
