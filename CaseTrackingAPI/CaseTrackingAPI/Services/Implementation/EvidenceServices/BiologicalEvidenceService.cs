using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces.EvidenceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation.EvidenceServices
{
    public class BiologicalEvidenceService : IBiologicalEvidenceService
    {
        private readonly IMapper _mapper;
        private readonly CaseDbContext _context;

        public BiologicalEvidenceService(IMapper mapper, CaseDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ActionResult<List<BiologicalEvidenceDTO>>> GetBiologicalEvidences() =>
            _mapper.Map<List<BiologicalEvidenceDTO>>(await _context.BiologicalEvidences.ToListAsync());

        public async Task<ActionResult> GetBiologicalEvidenceById(int id)
        {
            var mappedEvidence = _mapper.Map<BiologicalEvidenceDTO>(await _context.BiologicalEvidences.FindAsync(id));
            return mappedEvidence == null
                ? new NotFoundObjectResult("The evidence does not exist!")
                : new OkObjectResult(mappedEvidence);
        }

        public async Task<ActionResult> AddBiologicalEvidence(BiologicalEvidenceDTO evidenceDTO)
        {
            if (evidenceDTO == null)
                return new BadRequestObjectResult("The evidence cannot be null!");

            var mappedEvidence = _mapper.Map<BiologicalEvidence>(evidenceDTO);
            await _context.BiologicalEvidences.AddAsync(mappedEvidence);
            await _context.SaveChangesAsync();
            return new OkObjectResult("The evidence was successfully added!");
        }

        public async Task<ActionResult> UpdateBiologicalEvidence(int id, UpdateBiologicalEvidenceDTO updateEvidenceDTO)
        {
            if (updateEvidenceDTO == null)
                return new BadRequestObjectResult("The evidence cannot be null!");

            var dbEvidence = await _context.BiologicalEvidences.FindAsync(id);
            if (dbEvidence == null)
                return new NotFoundObjectResult("The evidence does not exist!");

            dbEvidence.Name = updateEvidenceDTO.Name ?? dbEvidence.Name;
            dbEvidence.RetrievalTime = updateEvidenceDTO.RetrievalTime ?? dbEvidence.RetrievalTime;
            dbEvidence.Location = updateEvidenceDTO.Location ?? dbEvidence.Location;
            dbEvidence.Attachment = updateEvidenceDTO.Attachment ?? dbEvidence.Attachment;
            dbEvidence.RetrievalTechnique = updateEvidenceDTO.RetrievalTechnique ?? dbEvidence.RetrievalTechnique;
            dbEvidence.Specification = updateEvidenceDTO.Specification ?? dbEvidence.Specification;
            dbEvidence.Type = updateEvidenceDTO.Type ?? dbEvidence.Type;
            dbEvidence.PersonId = updateEvidenceDTO.PersonId ?? dbEvidence.PersonId;

            await _context.SaveChangesAsync();

            return new OkObjectResult("The evidence was successfully updated!");
        }

        public async Task<ActionResult<List<BiologicalTraceDTO>>> Compare(int evidenceId, int personId)
        {
            // Retrieve the evidence by evidenceId
            var dbEvidence = _mapper.Map<BiologicalEvidenceDTO>(await _context.BiologicalEvidences.FindAsync(evidenceId));

            if (dbEvidence == null)
                return new NotFoundObjectResult("The evidence does not exist!");

            BiologicalTraceService biologicalTraceService = new(_context, _mapper);
            // Retrieve the list of traces for a person by personId
            var result = await biologicalTraceService.GetPersonTraces(personId);
            var objectList = result.Value;

            if (objectList == null)
                return new NotFoundObjectResult($"No biological traces were found for person {personId}!");

            List<BiologicalTraceDTO> traces = new();
            // Check if the evidence (dbEvidence) matches any "Type" and "Specification" from the objects in the list (objectList)
            foreach (var obj in objectList)
            {
                if (dbEvidence.Type == obj.Type && dbEvidence.Specification == obj.Specification)
                    traces.Add(obj);
            }
            return traces;
        }
    }
}
