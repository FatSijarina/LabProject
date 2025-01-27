using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("file/{id}")]
        public async Task<ActionResult<DFile>> GetFileById(int id)
            => await _fileService.GetFileById(id);

        [HttpGet("get-case-png/{caseId}")]
        public async Task<ActionResult<List<PNG>>> GetCasePngs(int caseId)
            => await _fileService.GetCasePngs(caseId);

        [HttpPost("upload/{caseId}")]
        public async Task<IActionResult> PostSingleFile(IFormFile fileData, int caseId)
        {
            if (fileData == null)
                return BadRequest("File data is null!");
            if (fileData.Length == 0) 
                return BadRequest("File is empty!");

            await _fileService.PostFileAsync(fileData, caseId);
            return Ok("File uploaded successfully!");
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFileById(int id)
        {
            await _fileService.DownloadFileById(id);
            return Ok("File downloaded successfully!");
        }
    }
}