using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers.EvidenceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiologicalEvidenceController : ControllerBase
    {
        private readonly IBiologicalEvidenceService _biologicalEvidenceService;

        public BiologicalEvidenceController(IBiologicalEvidenceService biologicalEvidenceService)
        {
            _biologicalEvidenceService = biologicalEvidenceService;
        }

        [HttpGet("biological-evidences")]
        public async Task<ActionResult<List<BiologicalEvidenceDTO>>> GetBiologicalEvidences()
        {
            return await _biologicalEvidenceService.GetBiologicalEvidences();
        }

        [HttpGet("biological-evidence/{id}")]
        public async Task<ActionResult> GetBiologicalEvidenceById(int id)
        {
            return await _biologicalEvidenceService.GetBiologicalEvidenceById(id);
        }

        [HttpPost("biological-evidence")]
        public async Task<ActionResult> AddBiologicalEvidence(BiologicalEvidenceDTO evidenceDTO)
        {
            return await _biologicalEvidenceService.AddBiologicalEvidence(evidenceDTO);
        }

        [HttpPut("biological-evidence/{id}")]
        public async Task<ActionResult> UpdateBiologicalEvidence(int id, UpdateBiologicalEvidenceDTO updateEvidenceDTO)
        {
            return await _biologicalEvidenceService.UpdateBiologicalEvidence(id, updateEvidenceDTO);
        }

        [HttpPost("biological-evidence/compare")]
        public async Task<ActionResult<List<BiologicalTraceDTO>>> Compare(int evidenceId, int personId)
        {
            return await _biologicalEvidenceService.Compare(evidenceId, personId);
        }

    }
}
