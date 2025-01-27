namespace CaseTrackingAPI.Services.Implementation.PersonsServices
{
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using global::CaseTrackingAPI.DTOs.PersonsDTOs;
    using global::CaseTrackingAPI.DTOs;
    using global::CaseTrackingAPI.Configurations;
    using global::CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
    using Microsoft.EntityFrameworkCore;

    namespace CaseTrackingAPI.Services.Implementation
    {
        public class InvolvedPartyService : IInvolvedParty
        {
            private readonly CaseDbContext _context;
            private readonly IMapper _mapper;
            /*
             * StatementService and BiologicalTraceService are instantiated in this class
             * so that the existing code is not repeated.
             * They are declared as class fields because they are used in more than one method
             * so it is more effective to have them here.
             */
            private readonly StatementService statementService;
            private readonly BiologicalTraceService biologicalTraceService;

            public InvolvedPartyService(CaseDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
                statementService = new StatementService(_context, _mapper);
                biologicalTraceService = new BiologicalTraceService(_context, _mapper);
            }

            public async Task<ActionResult> DeletePerson(int id)
            {
                var dbPerson = await _context.Persons.FindAsync(id);
                if (dbPerson == null)
                    return new NotFoundObjectResult("Person does not exist!");

                _context.Persons.Remove(dbPerson);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Person was successfully deleted!");
            }

            public async Task<ICollection<WitnessDTO>> GetWitnesses(int caseId) =>
                _mapper.Map<ICollection<WitnessDTO>>(await _context.Witnesses
                                    .Where(p => p.CaseId == caseId)
                                    .ToListAsync());

            public async Task<ICollection<SuspectDTO>> GetSuspects(int caseId) =>
                _mapper.Map<ICollection<SuspectDTO>>(await _context.Suspects
                                    .Where(p => p.CaseId == caseId)
                                    .ToListAsync());

            public async Task<ICollection<VictimDTO>> GetVictims(int caseId) =>
                _mapper.Map<ICollection<VictimDTO>>(await _context.Victims
                                        .Where(p => p.CaseId == caseId)
                                        .ToListAsync());

            public async Task<ActionResult<List<StatementDTO>>> GetStatementsOfPerson(int id) =>
                await statementService.GetPersonStatements(id);

            public async Task<ActionResult> AddStatement(StatementDTO statementDTO) =>
                new OkObjectResult(await statementService.AddStatement(statementDTO));

            public async Task<ActionResult> UpdateStatement(int id, UpdateStatementDTO updateStatementDTO) =>
                new OkObjectResult(await statementService.UpdateStatement(id, updateStatementDTO));

            public async Task<string> CompareStatements(int statement1Id, int statement2Id) =>
                await statementService.CompareStatements(statement1Id, statement2Id);

            public async Task<ActionResult<List<BiologicalTraceDTO>>> GetBiologicalTracesOfPerson(int id) =>
                await biologicalTraceService.GetPersonTraces(id);

            public async Task<ActionResult> AddBiologicalTrace(BiologicalTraceDTO biologicalTraceDTO) =>
                new OkObjectResult(await biologicalTraceService.AddBiologicalTrace(biologicalTraceDTO));

            public async Task<ActionResult> UpdateBiologicalTrace(int id, UpdateBiologicalTraceDTO updateBiologicalTraceDTO) =>
                new OkObjectResult(await biologicalTraceService.UpdateBiologicalTrace(id, updateBiologicalTraceDTO));
        }
    }

}
