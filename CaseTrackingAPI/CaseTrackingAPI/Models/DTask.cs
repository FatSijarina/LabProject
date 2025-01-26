namespace CaseTrackingAPI.Models
{
    public class DTask
    {
        public int Id { get; set; }
        public int? CaseId { get; set; }

        public string Title { get; set; } = null!;
        public string Details { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
    }
}