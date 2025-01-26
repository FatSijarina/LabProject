namespace CaseTrackingAPI.DTOs
{
    public class StatementDTO
    {
        public DateTime DateGiven { get; set; }
        public string Content { get; set; } = null!;
        public int PersonId { get; set; }
    }

    public class UpdateStatementDTO
    {
        public DateTime? DateGiven { get; set; }
        public string? Content { get; set; }
        public int? PersonId { get; set; }
    }
}
