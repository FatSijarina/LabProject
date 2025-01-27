using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers.EvidenceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalEvidenceController : ControllerBase
    {
        private readonly IPhysicalEvidenceService _physicalEvidenceService;

        public PhysicalEvidenceController(IPhysicalEvidenceService physicalEvidenceService)
        {
            _physicalEvidenceService = physicalEvidenceService;
        }

        [HttpGet("physical-evidences")]
        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetPhysicalEvidences()
        {
            return await _physicalEvidenceService.GetPhysicalEvidences();
        }

        [HttpGet("physical-evidence/{id}")]
        public async Task<ActionResult> GetPhysicalEvidenceById(int id)
        {
            return await _physicalEvidenceService.GetPhysicalEvidenceById(id);
        }

        [HttpGet("physical-evidences-requiring-examination")]
        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetRequiringExamination(bool requiresExamination)
        {
            return await _physicalEvidenceService.GetRequiringExamination(requiresExamination);
        }

        [HttpGet("physical-evidences-with-traces")]
        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetWithBiologicalTraces(bool hasTraces)
        {
            return await _physicalEvidenceService.GetWithBiologicalTraces(hasTraces);
        }

        [HttpGet("physical-evidences-by-risk-level")]
        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetByRiskLevel(string riskLevel)
        {
            return await _physicalEvidenceService.GetByRiskLevel(riskLevel);
        }

        [HttpPost("physical-evidence")]
        public async Task<ActionResult> AddPhysicalEvidence(PhysicalEvidenceDTO evidenceDTO)
        {
            return await _physicalEvidenceService.AddPhysicalEvidence(evidenceDTO);
        }

        [HttpPut("physical-evidence/{id}")]
        public async Task<ActionResult> UpdatePhysicalEvidence(int id, UpdatePhysicalEvidenceDTO updateEvidenceDTO)
        {
            return await _physicalEvidenceService.UpdatePhysicalEvidence(id, updateEvidenceDTO);
        }

    }
}
