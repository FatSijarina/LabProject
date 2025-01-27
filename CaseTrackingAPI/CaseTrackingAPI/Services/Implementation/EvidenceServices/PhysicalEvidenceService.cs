using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation.EvidenceServices
{
    public class PhysicalEvidenceService : IPhysicalEvidenceService
    {
        private readonly CaseDbContext _context;
        private readonly IMapper _mapper;

        public PhysicalEvidenceService(CaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetPhysicalEvidences() =>
            _mapper.Map<List<PhysicalEvidenceDTO>>(await _context.PhysicalEvidences.ToListAsync());

        public async Task<ActionResult> GetPhysicalEvidenceById(int id)
        {
            var mappedEvidence = _mapper.Map<PhysicalEvidenceDTO>(await _context.PhysicalEvidences.FindAsync(id));
            return mappedEvidence == null
                ? new NotFoundObjectResult("The evidence does not exist.")
                : new OkObjectResult(mappedEvidence);
        }

        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetRequiringExamination(bool requiresExamination)
        {
            return _mapper.Map<List<PhysicalEvidenceDTO>>(await _context.PhysicalEvidences
                .Where(e => e.RequiresExamination == requiresExamination)
                .ToListAsync());
        }

        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetWithBiologicalTraces(bool hasTraces)
        {
            return _mapper.Map<List<PhysicalEvidenceDTO>>(await _context.PhysicalEvidences
                .Where(e => e.ContainsBiologicalTraces == hasTraces)
                .ToListAsync());
        }

        public async Task<ActionResult<List<PhysicalEvidenceDTO>>> GetByRiskLevel(string riskLevel)
        {
            return _mapper.Map<List<PhysicalEvidenceDTO>>(await _context.PhysicalEvidences
                .Where(e => e.DangerLevel == riskLevel)
                .ToListAsync());
        }

        public async Task<ActionResult> AddPhysicalEvidence(PhysicalEvidenceDTO evidenceDTO)
        {
            if (evidenceDTO == null)
                return new BadRequestObjectResult("The evidence cannot be null!");

            var mappedEvidence = _mapper.Map<PhysicalEvidence>(evidenceDTO);
            await _context.PhysicalEvidences.AddAsync(mappedEvidence);
            await _context.SaveChangesAsync();
            return new OkObjectResult("The evidence was successfully added!");
        }

        public async Task<ActionResult> UpdatePhysicalEvidence(int id, UpdatePhysicalEvidenceDTO updateEvidenceDTO)
        {
            if (updateEvidenceDTO == null)
                return new BadRequestObjectResult("The evidence cannot be null!");

            var dbEvidence = await _context.PhysicalEvidences.FindAsync(id);
            if (dbEvidence == null)
                return new NotFoundObjectResult("The evidence does not exist!");

            dbEvidence.Name = updateEvidenceDTO.Name ?? dbEvidence.Name;
            dbEvidence.RetrievalTime = updateEvidenceDTO.RetrievalTime ?? dbEvidence.RetrievalTime;
            dbEvidence.Location = updateEvidenceDTO.Location ?? dbEvidence.Location;
            dbEvidence.Attachment = updateEvidenceDTO.Attachment ?? dbEvidence.Attachment;
            dbEvidence.UsedInCrime = updateEvidenceDTO.UsedInCrime ?? dbEvidence.UsedInCrime;
            dbEvidence.DangerLevel = updateEvidenceDTO.DangerLevel ?? dbEvidence.DangerLevel;
            dbEvidence.Classification = updateEvidenceDTO.Classification ?? dbEvidence.Classification;
            dbEvidence.RequiresExamination = updateEvidenceDTO.RequiresExamination ?? dbEvidence.RequiresExamination;
            dbEvidence.ContainsBiologicalTraces = updateEvidenceDTO.ContainsBiologicalTraces ?? dbEvidence.ContainsBiologicalTraces;
            dbEvidence.PersonId = updateEvidenceDTO?.PersonId ?? dbEvidence.PersonId;

            await _context.SaveChangesAsync();
            return new OkObjectResult("The evidence was successfully updated!");
        }
    }
}
