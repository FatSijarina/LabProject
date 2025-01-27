using CaseTrackingAPI.DTOs.EvidencesDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces
{
    public interface IEvidenceService
    {
        public Task<ActionResult<List<EvidenceDTO>>> GetEvidences();
        public Task<ActionResult> GetEvidenceById(int id);
        public Task<ActionResult> DeleteEvidence(int id);
    }
}
