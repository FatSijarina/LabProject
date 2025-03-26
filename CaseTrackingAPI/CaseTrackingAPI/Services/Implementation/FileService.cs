using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly CaseDbContext _context;
        private IFileUpload? _fileUpload;
        private readonly IMapper _mapper;
        private readonly Dictionary<string, IFileUpload> supportedFiles = new()
        {
            {"application/pdf", new PdfService() },
            {"image/png", new PngService() }
        };

        public FileService(CaseDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<DFile>> GetFileById(int id)
        {
            return await _context.Files.FindAsync(id);
        }
        public async Task<ActionResult<List<PNG>>> GetCasePngs(int caseId)
        {
            var casePngs = await _context
                                    .PNGs
                                    .Where(p => p.CaseId == caseId)
                                    .ToListAsync();
            if (casePngs == null)
                new BadRequestObjectResult("No images for this case.");
            return new OkObjectResult(casePngs);

        }

        public async Task PostFileAsync(IFormFile fileData, int caseId)
        {
            try
            {
                _fileUpload = supportedFiles[fileData.ContentType];
                if (_fileUpload == null)
                    throw new Exception("Unsupported file type.");

                var uploadedFile = _fileUpload.UploadFile(fileData, caseId);
                await _context.Files.AddAsync(uploadedFile);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        // download file in folder FilesDownloaded, if the folder does not exists, it will be created prior donwloading the file
        public async Task DownloadFileById(int id)
        {
            try
            {
                var file = await _context.Files.FindAsync(id);

                if (file != null)
                {
                    var content = new System.IO.MemoryStream(file.FileData);
                    var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "FilesDownloaded");
                    var path = Path.Combine(directoryPath, file.FileName);

                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    await CopyStream(content, path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


        private async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}