using CaseTrackingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces
{
    public interface IBiologicalTraceService
    {
        Task<ActionResult<List<BiologicalTraceDTO>>> GetBiologicalTraces();
        Task<ActionResult<BiologicalTraceDTO>> GetBiologicalTraceById(int id);
        Task<ActionResult<List<BiologicalTraceDTO>>> GetPersonTraces(int id);
        Task<ActionResult> AddBiologicalTrace(BiologicalTraceDTO biologicalTraceDTO);
        Task<ActionResult> UpdateBiologicalTrace(int id, UpdateBiologicalTraceDTO updateBiologicalTraceDTO);
        Task<ActionResult> DeleteBiologicalTrace(int id);
    }
}
