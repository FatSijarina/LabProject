using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers.PersonsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuspectController : ControllerBase
    {
        private readonly ISuspectService _suspectService;

        public SuspectController(ISuspectService suspectService)
        {
            _suspectService = suspectService;
        }

        [HttpGet("suspects")]
        public async Task<ActionResult<List<SuspectDTO>>> GetSuspects()
        {
            return await _suspectService.GetSuspects();
        }

        [HttpGet("suspect/{id}")]
        public async Task<ActionResult> GetSuspectById(int id)
        {
            return await _suspectService.GetSuspectById(id);
        }

        [HttpGet("suspect/{id}/suspicion")]
        public async Task<ActionResult<string>> GetSuspicionOnSuspect(int id)
        {
            return await _suspectService.GetSuspicionOnSuspect(id);
        }

        [HttpPost("suspect")]
        public async Task<ActionResult> AddSuspect(SuspectDTO suspectDTO)
        {
            return await _suspectService.AddSuspect(suspectDTO);
        }

        [HttpPut("suspect/{id}")]
        public async Task<ActionResult> UpdateSuspect(int id, UpdateSuspectDTO updateSuspectDTO)
        {
            return await _suspectService.UpdateSuspect(id, updateSuspectDTO);
        }

        [HttpGet("suspect/{id}/info")]
        public async Task<ActionResult<string>> GetInfo(int id)
        {
            return await _suspectService.GetInfo(id);
        }
    }
}
