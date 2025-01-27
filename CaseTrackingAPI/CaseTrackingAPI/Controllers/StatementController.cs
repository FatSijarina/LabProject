using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService)
        {
            _statementService = statementService;
        }

        [HttpGet("statements")]
        public async Task<ActionResult<List<StatementDTO>>> GetStatements()
        {
            return await _statementService.GetStatements();
        }

        [HttpGet("statement/{id}")]
        public async Task<ActionResult<StatementDTO>> GetStatementById(int id)
        {
            return await _statementService.GetStatementById(id);
        }

        [HttpGet("person-statements/{id}")]
        public async Task<ActionResult<List<StatementDTO>>> GetPersonStatements(int id)
        {
            return await _statementService.GetPersonStatements(id);
        }

        [HttpGet("statement-content/{id}")]
        public async Task<ActionResult<string>> GetStatementContent(int id)
        {
            return await _statementService.GetStatementContent(id);
        }

        [HttpPost("statement")]
        public async Task<ActionResult> AddStatement(StatementDTO statementDTO)
        {
            return await _statementService.AddStatement(statementDTO);
        }

        [HttpPut("statement/{id}")]
        public async Task<ActionResult> UpdateStatement(int id, UpdateStatementDTO updateStatementDTO)
        {
            return await _statementService.UpdateStatement(id, updateStatementDTO);
        }

        [HttpDelete("statement/{id}")]
        public async Task<ActionResult> DeleteStatement(int id)
        {
            return await _statementService.DeleteStatement(id);
        }

        [HttpGet("compare-statements")]
        public async Task<ActionResult<string>> CompareStatements(int s1Id, int s2Id)
        {
            return await _statementService.CompareStatements(s1Id, s2Id);
        }
    }
}
