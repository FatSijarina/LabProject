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

            public InvolvedPartyService(CaseDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
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
        }
    }
}