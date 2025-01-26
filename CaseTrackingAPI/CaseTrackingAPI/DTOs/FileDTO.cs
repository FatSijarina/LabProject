namespace CaseTrackingAPI.DTOs
{
    public class FileDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public DateTime DateUploaded { get; set; }
    }

    public class CasePngDTO : FileDTO
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
}