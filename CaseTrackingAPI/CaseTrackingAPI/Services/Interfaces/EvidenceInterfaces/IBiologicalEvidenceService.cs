using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces
{
    public interface IBiologicalEvidenceService
    {
        Task<ActionResult<List<BiologicalEvidenceDTO>>> GetBiologicalEvidences();

        Task<ActionResult> GetBiologicalEvidenceById(int id);

        Task<ActionResult> AddBiologicalEvidence(BiologicalEvidenceDTO evidenceDTO);

        Task<ActionResult> UpdateBiologicalEvidence(int id, UpdateBiologicalEvidenceDTO updateEvidenceDTO);

        Task<ActionResult<List<BiologicalTraceDTO>>> Compare(int evidenceId, int personId);
    }
}
