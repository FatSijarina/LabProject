using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseTrackingAPI.Services.Implementation.PersonsServices.CaseTrackingAPI.Services.Implementation;

namespace CaseTrackingAPI.Services.Implementation.PersonsServices
{
    public class VictimService : InvolvedPartyService,IVictimService
    {
        private readonly CaseDbContext _context;
        private readonly IMapper _mapper;

        public VictimService(CaseDbContext context, IMapper mapper): base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<VictimDTO>>> GetVictims()
        {
            var victims = await _context.Victims.ToListAsync();
            if (!victims.Any())
                return new NotFoundObjectResult("No victims registered!");

            var mappedVictims = _mapper.Map<List<VictimDTO>>(victims);

            foreach (var mappedVictim in mappedVictims)
            {
                var id = mappedVictim.Id;
                var statements = _context.Statements.Where(d => d.PersonId == id).ToList();
                mappedVictim.Statements = _mapper.Map<List<StatementDTO>>(statements);
                var traces = _context.BiologicalTraces.Where(g => g.PersonId == id).ToList();
                mappedVictim.BiologicalTraces = _mapper.Map<List<BiologicalTraceDTO>>(traces);
            }

            return new OkObjectResult(mappedVictims);
        }

        public async Task<ActionResult> GetVictimById(int id)
        {
            var victim = await _context.Victims.FindAsync(id);
            if (victim == null)
                return new NotFoundObjectResult("Victim does not exist!");

            var mappedVictim = _mapper.Map<VictimDTO>(victim);
            var statements = _context.Statements.Where(d => d.PersonId == id).ToList();
            mappedVictim.Statements = _mapper.Map<List<StatementDTO>>(statements);
            var traces = _context.BiologicalTraces.Where(g => g.PersonId == id).ToList();
            mappedVictim.BiologicalTraces = _mapper.Map<List<BiologicalTraceDTO>>(traces);

            return new OkObjectResult(mappedVictim);
        }

        public async Task<ActionResult> AddVictim(VictimDTO victimDTO)
        {
            if (victimDTO == null)
                return new BadRequestObjectResult("Victim cannot be null!");

            var mappedVictim = _mapper.Map<Victim>(victimDTO);
            await _context.Victims.AddAsync(mappedVictim);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Victim successfully added!");
        }

        public async Task<ActionResult> UpdateVictim(int id, UpdateVictimDTO updateVictimDTO)
        {
            if (updateVictimDTO == null)
                return new BadRequestObjectResult("Victim cannot be null!");

            var dbVictim = await _context.Victims.FindAsync(id);
            if (dbVictim == null)
                return new NotFoundObjectResult("Victim does not exist!");

            dbVictim.Name = updateVictimDTO.Name ?? dbVictim.Name;
            dbVictim.Gender = updateVictimDTO.Gender ?? dbVictim.Gender;
            dbVictim.Profession = updateVictimDTO.Profession ?? dbVictim.Profession;
            dbVictim.Status = updateVictimDTO.Status ?? dbVictim.Status;
            dbVictim.Residence = updateVictimDTO.Residence ?? dbVictim.Residence;
            dbVictim.MentalState = updateVictimDTO.MentalState ?? dbVictim.MentalState;
            dbVictim.Background = updateVictimDTO.Background ?? dbVictim.Background;
            dbVictim.Location = updateVictimDTO.Location ?? dbVictim.Location;
            dbVictim.Time = updateVictimDTO.Time ?? dbVictim.Time;
            dbVictim.Method = updateVictimDTO.Method ?? dbVictim.Method;
            dbVictim.Condition = updateVictimDTO.Condition ?? dbVictim.Condition;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Victim successfully updated!");
        }

        public async Task<ActionResult<string>> GetInfo(int id)
        {
            var dbVictim = await _context.Victims.FindAsync(id);
            return dbVictim == null
                ? "Victim does not exist!"
                : $"Victim: Name -> {dbVictim.Name}, Profession -> {dbVictim.Profession}, Residence -> {dbVictim.Residence}, \nWhere was found? {dbVictim.Location}, \nWhen was found? {dbVictim.Time}, \nHow was found? {dbVictim.Method}, \nWhat condition was found in? {dbVictim.Condition}.";
        }
    }
}
