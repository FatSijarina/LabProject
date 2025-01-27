using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation
{
    public class CaseService : ICaseService
    {
        private readonly IMapper _mapper;
        private readonly CaseDbContext _context;
        private readonly IInvolvedParty _involvedParty;

        public CaseService(IMapper mapper, CaseDbContext context, IInvolvedParty involvedParty)
        {
            _mapper = mapper;
            _context = context;
            _involvedParty = involvedParty;
        }

        public async Task<ActionResult<List<GetCasesDetailsDTO>>> GetCases()
            => _mapper.Map<List<GetCasesDetailsDTO>>(await _context.Cases.ToListAsync());

        public async Task<ActionResult<List<GetCaseDTO>>> GetCaseById(int id)
        {
            var dCase = await _context.Cases.FindAsync(id);
            if (dCase == null)
                return new NotFoundObjectResult("Case doesn't exist!");

            var mappedCase = _mapper.Map<GetCaseDTO>(dCase);

            mappedCase.Victims = await _involvedParty.GetVictims(id);
            mappedCase.Witnesses = await _involvedParty.GetWitnesses(id);
            mappedCase.Suspects = await _involvedParty.GetSuspects(id);

            return new OkObjectResult(mappedCase);
        }

        public async Task<ActionResult> AddCase(AddCaseDTO caseDTO)
        {
            if (caseDTO == null)
                return new BadRequestObjectResult("You can't add an empty case!");
            var mappedCase = _mapper.Map<DCase>(caseDTO);
            await _context.Cases.AddAsync(mappedCase);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Case added successfully!");
        }

        public async Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO)
        {
            if (updateCaseDTO == null)
                return new BadRequestObjectResult("Nothing to be updated!");

            var dbCase = await _context.Cases.FindAsync(id);
            if (dbCase == null)
                return new NotFoundObjectResult("Case doesn't exist!");

            dbCase.ImageUrl = updateCaseDTO.ImageUrl ?? dbCase.ImageUrl;
            dbCase.Identifier = updateCaseDTO.Identifier ?? dbCase.Identifier;
            dbCase.Title = updateCaseDTO.Title ?? dbCase.Title;
            dbCase.Status = updateCaseDTO.Status ?? dbCase.Status;
            dbCase.Details = updateCaseDTO.Details ?? dbCase.Details;
            dbCase.DateClosed = updateCaseDTO.DateClosed ?? dbCase.DateClosed;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Case updated successfully!");
        }

        public async Task<ActionResult> DeleteCase(int id)
        {
            var dbCase = await _context.Cases.FindAsync(id);
            if (dbCase == null)
                return new NotFoundObjectResult("Case doesn't exist!");

            _context.Cases.Remove(dbCase);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Case deleted successfully!");
        }

        public async Task<ActionResult> ChangeCaseStatus(int id, string status)
        {
            var dbCase = await _context.Cases.FindAsync(id);
            if (dbCase == null)
                return new NotFoundObjectResult("Case doesn't exist!");

            dbCase.Status = status;

            await _context.SaveChangesAsync();
            return new OkObjectResult("Case updated succesfully!");
        }
    }
}