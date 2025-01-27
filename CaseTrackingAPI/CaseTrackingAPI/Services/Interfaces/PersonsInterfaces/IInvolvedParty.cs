using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.PersonsInterfaces
{
    public interface IInvolvedParty
    {
        Task<ActionResult> DeletePerson(int id);

        Task<ICollection<WitnessDTO>> GetWitnesses(int caseId);

        Task<ICollection<SuspectDTO>> GetSuspects(int caseId);

        Task<ICollection<VictimDTO>> GetVictims(int caseId);

        Task<ActionResult<List<StatementDTO>>> GetStatementsOfPerson(int id);

        Task<ActionResult> AddStatement(StatementDTO statementDTO);

        Task<ActionResult> UpdateStatement(int id, UpdateStatementDTO updateStatementDTO);

        Task<string> CompareStatements(int statement1Id, int statement2Id);

        Task<ActionResult<List<BiologicalTraceDTO>>> GetBiologicalTracesOfPerson(int id);

        Task<ActionResult> AddBiologicalTrace(BiologicalTraceDTO biologicalTraceDTO);

        Task<ActionResult> UpdateBiologicalTrace(int id, UpdateBiologicalTraceDTO updateBiologicalTraceDTO);
    }
}
