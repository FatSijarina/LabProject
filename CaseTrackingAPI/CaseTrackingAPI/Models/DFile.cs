namespace CaseTrackingAPI.Models
{
    public class DFile
    {
        public int Id { get; set; }
        public DateTime DateUploaded { get; set; } = DateTime.Now;
        public string FileName { get; set; } = null!;
        public byte[] FileData { get; set; } = null!;
        public int CaseId { get; set; }
    }
}