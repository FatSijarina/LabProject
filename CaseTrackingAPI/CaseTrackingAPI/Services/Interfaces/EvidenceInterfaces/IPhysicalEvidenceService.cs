using CaseTrackingAPI.DTOs.EvidencesDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces
{
    public interface IPhysicalEvidenceService
    {
        Task<ActionResult<List<PhysicalEvidenceDTO>>> GetPhysicalEvidences();

        Task<ActionResult> GetPhysicalEvidenceById(int id);

        Task<ActionResult<List<PhysicalEvidenceDTO>>> GetRequiringExamination(bool needsExamination);

        Task<ActionResult<List<PhysicalEvidenceDTO>>> GetWithBiologicalTraces(bool hasBiologicalTraces);

        Task<ActionResult<List<PhysicalEvidenceDTO>>> GetByRiskLevel(string riskLevel);

        Task<ActionResult> AddPhysicalEvidence(PhysicalEvidenceDTO evidenceDTO);

        Task<ActionResult> UpdatePhysicalEvidence(int id, UpdatePhysicalEvidenceDTO updateEvidenceDTO);
    }
}
