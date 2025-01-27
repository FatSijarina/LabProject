using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers.PersonsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VictimController : ControllerBase
    {
        private readonly IVictimService _victimService;

        public VictimController(IVictimService victimService)
        {
            _victimService = victimService;
        }

        [HttpGet("victims")]
        public async Task<ActionResult<List<VictimDTO>>> GetVictims()
        {
            return await _victimService.GetVictims();
        }

        [HttpGet("victim/{id}")]
        public async Task<ActionResult> GetVictimById(int id)
        {
            return await _victimService.GetVictimById(id);
        }

        [HttpPost("victim")]
        public async Task<ActionResult> AddVictim(VictimDTO victimDTO)
        {
            return await _victimService.AddVictim(victimDTO);
        }

        [HttpPut("victim/{id}")]
        public async Task<ActionResult> UpdateVictim(int id, UpdateVictimDTO updateVictimDTO)
        {
            return await _victimService.UpdateVictim(id, updateVictimDTO);
        }

        [HttpGet("victim/{id}/info")]
        public async Task<ActionResult<string>> GetInfo(int id)
        {
            return await _victimService.GetInfo(id);
        }
    }
}
