using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers.EvidenceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenceController : ControllerBase
    {
        private readonly IEvidenceService _evidenceService;

        public EvidenceController(IEvidenceService evidenceService)
        {
            _evidenceService = evidenceService;
        }

        [HttpGet("evidences")]
        public async Task<ActionResult<List<EvidenceDTO>>> GetEvidences()
        {
            return await _evidenceService.GetEvidences();
        }

        [HttpGet("evidence/{id}")]
        public async Task<ActionResult> GetEvidenceById(int id)
        {
            return await _evidenceService.GetEvidenceById(id);
        }

        [HttpDelete("evidence/{id}")]
        public async Task<ActionResult> DeleteEvidence(int id)
        {
            return await _evidenceService.DeleteEvidence(id);
        }
    }
}
