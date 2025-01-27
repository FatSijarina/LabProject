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
        {
            return await _involvedParty.DeletePerson(id);
        }

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


        [HttpGet("{id}/statements")]
        public async Task<ActionResult<List<StatementDTO>>> GetStatementsOfPerson(int id)
        {
            return await _involvedParty.GetStatementsOfPerson(id);
        }

        [HttpPost("statement")]
        public async Task<ActionResult> AddStatement(StatementDTO statementDTO)
        {
            return await _involvedParty.AddStatement(statementDTO);
        }

        [HttpPut("statement/{id}")]
        public async Task<ActionResult> UpdateStatement(int id, UpdateStatementDTO updateStatementDTO)
        {
            return await _involvedParty.UpdateStatement(id, updateStatementDTO);
        }

        [HttpPost("compare-statements")]
        public async Task<ActionResult<string>> CompareStatements(int statement1Id, int statement2Id)
        {
            return await _involvedParty.CompareStatements(statement1Id, statement2Id);
        }

        [HttpGet("{id}/biological-traces")]
        public async Task<ActionResult<List<BiologicalTraceDTO>>> GetBiologicalTracesOfPerson(int id)
        {
            return await _involvedParty.GetBiologicalTracesOfPerson(id);
        }

        [HttpPost("biological-trace")]
        public async Task<ActionResult> AddBiologicalTrace(BiologicalTraceDTO biologicalTraceDTO)
        {
            return await _involvedParty.AddBiologicalTrace(biologicalTraceDTO);
        }

        [HttpPut("biological-trace/{id}")]
        public async Task<ActionResult> UpdateBiologicalTrace(int id, UpdateBiologicalTraceDTO updateBiologicalTraceDTO)
        {
            return await _involvedParty.UpdateBiologicalTrace(id, updateBiologicalTraceDTO);
        }
    }
}
