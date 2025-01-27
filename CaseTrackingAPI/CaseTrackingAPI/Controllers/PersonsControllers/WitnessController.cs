using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers.PersonsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WitnessController : ControllerBase
    {
        private readonly IWitnessService _witnessService;

        public WitnessController(IWitnessService witnessService)
        {
            _witnessService = witnessService;
        }

        [HttpGet("witnesses")]
        public async Task<ActionResult<List<WitnessDTO>>> GetWitnesses()
        {
            return await _witnessService.GetWitnesses();
        }

        [HttpGet("witness/{id}")]
        public async Task<ActionResult> GetWitnessById(int id)
        {
            return await _witnessService.GetWitnessById(id);
        }

        [HttpGet("witness/{id}/info")]
        public async Task<ActionResult<string>> GetInfo(int id)
        {
            return await _witnessService.GetInfo(id);
        }

        [HttpGet("witness/{id}/is-suspected")]
        public async Task<ActionResult<bool>> ISuspected(int id)
        {
            return await _witnessService.ISuspected(id);
        }

        [HttpGet("witness/{id}/is-observed")]
        public async Task<ActionResult<bool>> IsObserved(int id)
        {
            return await _witnessService.IsObserved(id);
        }

        [HttpPost("witness")]
        public async Task<ActionResult> AddWitness(WitnessDTO witnessDTO)
        {
            return await _witnessService.AddWitness(witnessDTO);
        }

        [HttpPut("witness/{id}")]
        public async Task<ActionResult> UpdateWitness(int id, UpdateWitnessDTO updateWitnessDTO)
        {
            return await _witnessService.UpdateWitness(id, updateWitnessDTO);
        }

        [HttpPost("witness/{id}/save-as-suspect")]
        public async Task<ActionResult> SaveAsSuspect(int id)
        {
            return await _witnessService.SaveAsSuspect(id);
        }
    }
}
