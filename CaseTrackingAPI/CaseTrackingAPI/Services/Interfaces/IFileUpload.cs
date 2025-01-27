using CaseTrackingAPI.Models;

namespace CaseTrackingAPI.Services.Interfaces
{
    public interface IFileUpload
    {
        public DFile UploadFile(IFormFile uploadedFile, int caseId);
    }
}