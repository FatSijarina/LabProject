using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers.PersonsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IInvolvedParty _involvedParty;

        public PersonController(IInvolvedParty involvedParty)
        {
            _involvedParty = involvedParty;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
            => await _involvedParty.DeletePerson(id);

        [HttpGet("{caseId}/witnesses")]
        public async Task<ActionResult<ICollection<WitnessDTO>>> GetWitnesses(int caseId)
        {
            var witnesses = await _involvedParty.GetWitnesses(caseId);
            return Ok(witnesses);
        }

        [HttpGet("{caseId}/suspects")]
        public async Task<ActionResult<ICollection<SuspectDTO>>> GetSuspects(int caseId)
        {
            var suspects = await _involvedParty.GetSuspects(caseId);
            return Ok(suspects);
        }

        [HttpGet("{caseId}/victims")]
        public async Task<ActionResult<ICollection<VictimDTO>>> GetVictims(int caseId)
        {
            var victims = await _involvedParty.GetVictims(caseId);
            return Ok(victims);
        }
    }
}