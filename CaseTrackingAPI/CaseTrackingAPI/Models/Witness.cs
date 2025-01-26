namespace CaseTrackingAPI.Models
{
    public class Witness : Person
    {
        public string? RelationToVictim { get; set; }
        public bool IsUnderObservation { get; set; }
        public bool IsSuspected { get; set; }
    }
}
