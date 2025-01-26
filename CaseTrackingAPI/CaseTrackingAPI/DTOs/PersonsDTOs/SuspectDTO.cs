namespace CaseTrackingAPI.DTOs.PersonsDTOs
{
    public class SuspectDTO : PersonDTO
    {
        public string Suspicion { get; set; } = null!;
    }

    public class UpdateSuspectDTO : UpdatePersonDTO
    {
        public string? Suspicion { get; set; }
    }
}
