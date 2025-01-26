namespace CaseTrackingAPI.DTOs.PersonsDTOs
{
    public class WitnessDTO : PersonDTO
    {
        public string RelationToVictim { get; set; } = null!;
        public bool IsUnderObservation { get; set; }
        public bool IsSuspected { get; set; }
    }

    public class UpdateWitnessDTO : UpdatePersonDTO
    {
        public string? RelationToVictim { get; set; }
        public bool? IsUnderObservation { get; set; }
        public bool? IsSuspected { get; set; }
    }
}
