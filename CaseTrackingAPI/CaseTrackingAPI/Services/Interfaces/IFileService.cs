using CaseTrackingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces
{
    public interface IFileService
    {
        public Task<ActionResult<DFile>> GetFileById(int id);
        public Task<ActionResult<List<PNG>>> GetCasePngs(int caseId);
        public Task PostFileAsync(IFormFile fileData, int caseId);

        public Task DownloadFileById(int fileName);
    }
}