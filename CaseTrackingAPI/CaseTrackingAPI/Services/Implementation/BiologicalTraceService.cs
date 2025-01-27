using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation
{
    public class BiologicalTraceService : IBiologicalTraceService
    {
        private readonly CaseDbContext _context;
        private readonly IMapper _mapper;

        public BiologicalTraceService(CaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<BiologicalTraceDTO>>> GetBiologicalTraces() =>
            _mapper.Map<List<BiologicalTraceDTO>>(await _context.BiologicalTraces.ToListAsync());

        public async Task<ActionResult<BiologicalTraceDTO>> GetBiologicalTraceById(int id)
        {
            var mappedTrace = _mapper.Map<BiologicalTraceDTO>(await _context.BiologicalTraces.FindAsync(id));
            return mappedTrace == null
                ? new NotFoundObjectResult("Trace does not exist.")
                : new OkObjectResult(mappedTrace);
        }

        public async Task<ActionResult<List<BiologicalTraceDTO>>> GetPersonTraces(int id)
        {
            var dbPerson = await _context.Persons.FindAsync(id);
            return dbPerson == null
                ? new NotFoundObjectResult("Person does not exist!")
                : _mapper.Map<List<BiologicalTraceDTO>>(await _context.BiologicalTraces
                                .Where(p => p.Person.Id == id)
                                .ToListAsync());
        }

        public async Task<ActionResult> AddBiologicalTrace(BiologicalTraceDTO biologicalTraceDTO)
        {
            if (biologicalTraceDTO == null)
                return new BadRequestObjectResult("Trace cannot be null!");
            var mappedTrace = _mapper.Map<BiologicalTrace>(biologicalTraceDTO);
            await _context.BiologicalTraces.AddAsync(mappedTrace);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Trace added successfully!");
        }

        public async Task<ActionResult> UpdateBiologicalTrace(int id, UpdateBiologicalTraceDTO updateBiologicalTraceDTO)
        {
            if (updateBiologicalTraceDTO == null)
                return new BadRequestObjectResult("Trace cannot be null!");

            var dbTrace = await _context.BiologicalTraces.FindAsync(id);
            if (dbTrace == null)
                return new NotFoundObjectResult("Trace does not exist!");

            dbTrace.Name = updateBiologicalTraceDTO.Name ?? dbTrace.Name;
            dbTrace.Type = updateBiologicalTraceDTO.Type ?? dbTrace.Type;
            dbTrace.Specification = updateBiologicalTraceDTO.Specification ?? dbTrace.Specification;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Trace updated successfully!");
        }

        public async Task<ActionResult> DeleteBiologicalTrace(int id)
        {
            var dbTrace = await _context.BiologicalTraces.FindAsync(id);
            if (dbTrace == null)
                return new NotFoundObjectResult("Trace does not exist!");

            _context.BiologicalTraces.Remove(dbTrace);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Trace deleted successfully!");
        }
    }
}
