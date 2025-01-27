using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation.EvidenceServices
{
    public class EvidenceService : IEvidenceService
    {
        private readonly CaseDbContext _context;
        private readonly IMapper _mapper;

        public EvidenceService(CaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<EvidenceDTO>>> GetEvidences() =>
            _mapper.Map<List<EvidenceDTO>>(await _context.Evidences.ToListAsync());

        public async Task<ActionResult> GetEvidenceById(int id)
        {
            var mappedEvidence = _mapper.Map<EvidenceDTO>(await _context.Evidences.FindAsync(id));
            return mappedEvidence == null
                ? new NotFoundObjectResult("The evidence does not exist.")
                : new OkObjectResult(mappedEvidence);
        }

        public async Task<ActionResult> DeleteEvidence(int id)
        {
            var dbEvidence = await _context.Evidences.FindAsync(id);
            if (dbEvidence == null)
                return new NotFoundObjectResult("The evidence does not exist!!");

            _context.Evidences.Remove(dbEvidence);
            await _context.SaveChangesAsync();
            return new OkObjectResult("The evidence was successfully deleted!");
        }
    }

}
