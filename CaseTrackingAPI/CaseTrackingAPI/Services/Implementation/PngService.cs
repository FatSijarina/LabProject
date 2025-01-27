using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces;

namespace CaseTrackingAPI.Services.Implementation
{
    public class PngService : IFileUpload
    {
        public PngService() { }

        public DFile UploadFile(IFormFile uploadedFile, int caseId)
        {
            try
            {
                PNG png = new()
                {
                    CaseId = caseId,
                    FileName = uploadedFile.FileName
                };

                var stream = new MemoryStream();

                uploadedFile.CopyTo(stream);
                png.FileData = stream.ToArray();
                return png;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}