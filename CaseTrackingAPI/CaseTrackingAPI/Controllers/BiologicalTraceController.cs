using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiologicalTraceController : ControllerBase
    {
        private readonly IBiologicalTraceService _biologicalTraceService;
        public BiologicalTraceController(IBiologicalTraceService biologicalTraceService)
        {
            _biologicalTraceService = biologicalTraceService;
        }

        [HttpGet("biological-traces")]
        public async Task<ActionResult<List<BiologicalTraceDTO>>> GetBiologicalTraces()
        {
            return await _biologicalTraceService.GetBiologicalTraces();
        }

        [HttpGet("biological-trace/{id}")]
        public async Task<ActionResult<BiologicalTraceDTO>> GetBiologicalTraceById(int id)
        {
            return await _biologicalTraceService.GetBiologicalTraceById(id);
        }

        [HttpGet("person-traces/{id}")]
        public async Task<ActionResult<List<BiologicalTraceDTO>>> GetPersonTraces(int id)
        {
            return await _biologicalTraceService.GetPersonTraces(id);
        }

        [HttpPost("biological-trace")]
        public async Task<ActionResult> AddBiologicalTrace(BiologicalTraceDTO biologicalTraceDTO)
        {
            return await _biologicalTraceService.AddBiologicalTrace(biologicalTraceDTO);
        }

        [HttpPut("biological-trace/{id}")]
        public async Task<ActionResult> UpdateBiologicalTrace(int id, UpdateBiologicalTraceDTO updateBiologicalTraceDTO)
        {
            return await _biologicalTraceService.UpdateBiologicalTrace(id, updateBiologicalTraceDTO);
        }

        [HttpDelete("biological-trace/{id}")]
        public async Task<ActionResult> DeleteBiologicalTrace(int id)
        {
            return await _biologicalTraceService.DeleteBiologicalTrace(id);
        }
    }
}
