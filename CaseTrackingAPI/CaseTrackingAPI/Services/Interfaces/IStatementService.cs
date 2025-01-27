using CaseTrackingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces
{
    public interface IStatementService
    {
        Task<ActionResult<List<StatementDTO>>> GetStatements();
        Task<ActionResult<StatementDTO>> GetStatementById(int id);
        Task<ActionResult<List<StatementDTO>>> GetPersonStatements(int id);
        Task<ActionResult<string>> GetStatementContent(int id);
        Task<ActionResult> AddStatement(StatementDTO statementDTO);
        Task<ActionResult> UpdateStatement(int id, UpdateStatementDTO updateStatementDTO);
        Task<ActionResult> DeleteStatement(int id);
        Task<string> CompareStatements(int s1Id, int s2Id);
    }
}
