using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using CaseTrackingAPI.Services.Implementation.PersonsServices.CaseTrackingAPI.Services.Implementation;

namespace CaseTrackingAPI.Services.Implementation.PersonsServices
{
    public class SuspectService : InvolvedPartyService, ISuspectService
    {
        private readonly CaseDbContext _context;
        private readonly IMapper _mapper;

        public SuspectService(CaseDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<SuspectDTO>>> GetSuspects()
        {
            var suspects = await _context.Suspects.ToListAsync();
            if (!suspects.Any())
                return new NotFoundObjectResult("No suspects are registered!");

            var mappedSuspects = _mapper.Map<List<SuspectDTO>>(suspects);

            foreach (var mappedSuspect in mappedSuspects)
            {
                var id = mappedSuspect.Id;
                var statements = _context.Statements.Where(d => d.PersonId == id).ToList();
                mappedSuspect.Statements = _mapper.Map<List<StatementDTO>>(statements);
                var traces = _context.BiologicalTraces.Where(g => g.PersonId == id).ToList();
                mappedSuspect.BiologicalTraces = _mapper.Map<List<BiologicalTraceDTO>>(traces);
            }

            return new OkObjectResult(mappedSuspects);
        }

        public async Task<ActionResult> GetSuspectById(int id)
        {
            var suspect = await _context.Suspects.FindAsync(id);
            if (suspect == null)
                return new NotFoundObjectResult("Suspect does not exist!");

            var mappedSuspect = _mapper.Map<SuspectDTO>(suspect);
            var statements = _context.Statements.Where(d => d.PersonId == id).ToList();
            mappedSuspect.Statements = _mapper.Map<List<StatementDTO>>(statements);
            var traces = _context.BiologicalTraces.Where(g => g.PersonId == id).ToList();
            mappedSuspect.BiologicalTraces = _mapper.Map<List<BiologicalTraceDTO>>(traces);

            return new OkObjectResult(mappedSuspect);
        }

        public async Task<ActionResult<string>> GetSuspicionOnSuspect(int id)
        {
            var suspect = await _context.Suspects.FindAsync(id);
            return suspect == null
                ? new NotFoundObjectResult("The person is not under suspicion!")
                : suspect.Suspicion;
        }

        public async Task<ActionResult> AddSuspect(SuspectDTO suspectDto)
        {
            if (suspectDto == null)
                return new BadRequestObjectResult("Suspect cannot be null!");

            var mappedSuspect = _mapper.Map<Suspect>(suspectDto);
            await _context.Suspects.AddAsync(mappedSuspect);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Suspect was successfully added!");
        }

        public async Task<ActionResult> UpdateSuspect(int id, UpdateSuspectDTO updateSuspectDto)
        {
            if (updateSuspectDto == null)
                return new BadRequestObjectResult("Suspect cannot be null!");

            var dbSuspect = await _context.Suspects.FindAsync(id);
            if (dbSuspect == null)
                return new NotFoundObjectResult("Suspect does not exist!");

            dbSuspect.Name = updateSuspectDto.Name ?? dbSuspect.Name;
            dbSuspect.Gender = updateSuspectDto.Gender ?? dbSuspect.Gender;
            dbSuspect.Profession = updateSuspectDto.Profession ?? dbSuspect.Profession;
            dbSuspect.Status = updateSuspectDto.Status ?? dbSuspect.Status;
            dbSuspect.Residence = updateSuspectDto.Residence ?? dbSuspect.Residence;
            dbSuspect.MentalState = updateSuspectDto.MentalState ?? dbSuspect.MentalState;
            dbSuspect.Background = updateSuspectDto.Background?? dbSuspect.Background;
            dbSuspect.Suspicion = updateSuspectDto.Suspicion ?? dbSuspect.Suspicion;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Suspect was successfully updated!");
        }

        public async Task<ActionResult<string>> GetInfo(int id)
        {
            var dbSuspect = await _context.Suspects.FindAsync(id);
            return dbSuspect == null
                ? "Suspect does not exist!"
                : $"Suspect: Name -> {dbSuspect.Name}, Profession -> {dbSuspect.Profession}, Residence -> {dbSuspect.Residence}, \nReason for suspicion: {dbSuspect.Suspicion}.";
        }
    }
}
