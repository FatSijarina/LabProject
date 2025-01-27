using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _caseService;

        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
        }

        [HttpGet("cases")]
        public async Task<ActionResult<List<GetCasesDetailsDTO>>> GetCases()
            => await _caseService.GetCases();

        [HttpGet("case/{id}")]
        public async Task<ActionResult<List<GetCaseDTO>>> GetCaseById(int id)
            => await _caseService.GetCaseById(id);

        [HttpPost("case")]
        public async Task<ActionResult> AddCase(AddCaseDTO caseDTO)
            => await _caseService.AddCase(caseDTO);

        [HttpPut("case/{id}")]
        public async Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO)
            => await _caseService.UpdateCase(id, updateCaseDTO);

        [HttpDelete("case/{id}")]
        public async Task<ActionResult> DeleteCase(int id)
            => await _caseService.DeleteCase(id);

        [HttpPatch("change-case-status/{id}")]
        public async Task<ActionResult> ChangeCaseStatus(int id, string status)
            => await _caseService.ChangeCaseStatus(id, status);
    }
}