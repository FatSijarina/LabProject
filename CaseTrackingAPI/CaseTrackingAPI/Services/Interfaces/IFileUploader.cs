namespace CaseTrackingAPI.Services.Interfaces
{
    public interface IFileUploader
    {
        Task<bool> UploadFile(IFormFile file);
    }
}