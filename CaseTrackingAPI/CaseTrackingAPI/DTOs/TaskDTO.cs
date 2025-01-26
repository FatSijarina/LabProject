namespace CaseTrackingAPI.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public int? CaseId { get; set; }
        public string Title { get; set; } = null!;
        public string Details { get; set; } = null!;
        public bool Statusi { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }

    }

    public class UpdateTaskDTO
    {
        public string Title { get; set; } = null!;
        public string Details { get; set; }
        public bool Statusi { get; set; }
        public DateTime DueDate { get; set; }
    }
}