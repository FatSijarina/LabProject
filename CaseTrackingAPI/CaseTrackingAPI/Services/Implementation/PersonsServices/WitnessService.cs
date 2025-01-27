using AutoMapper;
using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces.PersonsInterfaces;
using Microsoft.AspNetCore.Mvc;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.Services.Implementation.PersonsServices.CaseTrackingAPI.Services.Implementation;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation.PersonsServices
{
    public class WitnessService : InvolvedPartyService, IWitnessService
    {
        private readonly CaseDbContext _context;
        private readonly IMapper _mapper;

        public WitnessService(CaseDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<WitnessDTO>>> GetWitnesses()
        {
            var witnesses = await _context.Witnesses.ToListAsync();
            if (!witnesses.Any())
                return new NotFoundObjectResult("No witnesses registered!");

            var mappedWitnesses = _mapper.Map<List<WitnessDTO>>(witnesses);

            foreach (var mappedWitness in mappedWitnesses)
            {
                var id = mappedWitness.Id;
                var statements = _context.Statements.Where(s => s.PersonId == id).ToList();
                mappedWitness.Statements = _mapper.Map<List<StatementDTO>>(statements);
                var traces = _context.BiologicalTraces.Where(t => t.PersonId == id).ToList();
                mappedWitness.BiologicalTraces = _mapper.Map<List<BiologicalTraceDTO>>(traces);
            }

            return new OkObjectResult(mappedWitnesses);
        }

        public async Task<ActionResult> GetWitnessById(int id)
        {
            var witness = await _context.Witnesses.FindAsync(id);
            if (witness == null)
                return new NotFoundObjectResult("Witness does not exist!!");

            var mappedWitness = _mapper.Map<WitnessDTO>(witness);
            var statements = _context.Statements.Where(s => s.PersonId == id).ToList();
            mappedWitness.Statements = _mapper.Map<List<StatementDTO>>(statements);
            var traces = _context.BiologicalTraces.Where(t => t.PersonId == id).ToList();
            mappedWitness.BiologicalTraces = _mapper.Map<List<BiologicalTraceDTO>>(traces);

            return new OkObjectResult(mappedWitness);
        }

        public async Task<ActionResult<bool>> ISuspected(int id)
        {
            var dbWitness = await _context.Witnesses.FindAsync(id);
            if (dbWitness == null)
                return new NotFoundObjectResult("Witness does not exist!!");
            return dbWitness.IsSuspected;
        }

        public async Task<ActionResult<bool>> IsObserved(int id)
        {
            var dbWitness = await _context.Witnesses.FindAsync(id);
            if (dbWitness == null)
                return new NotFoundObjectResult("Witness does not exist!!");
            return dbWitness.IsUnderObservation;
        }

        public async Task<ActionResult> AddWitness(WitnessDTO witnessDTO)
        {
            if (witnessDTO == null)
                return new BadRequestObjectResult("Witness cannot be null!!");
            var mappedWitness = _mapper.Map<Witness>(witnessDTO);
            await _context.Witnesses.AddAsync(mappedWitness);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Witness added successfully!");
        }

        public async Task<ActionResult> UpdateWitness(int id, UpdateWitnessDTO updateWitnessDTO)
        {
            if (updateWitnessDTO == null)
                return new BadRequestObjectResult("Witness cannot be null!!");

            var dbWitness = await _context.Witnesses.FindAsync(id);
            if (dbWitness == null)
                return new NotFoundObjectResult("Witness does not exist!!");

            dbWitness.Name = updateWitnessDTO.Name ?? dbWitness.Name;
            dbWitness.Gender = updateWitnessDTO.Gender ?? dbWitness.Gender;
            dbWitness.Profession = updateWitnessDTO.Profession ?? dbWitness.Profession;
            dbWitness.Status = updateWitnessDTO.Status ?? dbWitness.Status;
            dbWitness.Residence = updateWitnessDTO.Residence ?? dbWitness.Residence;
            dbWitness.MentalState = updateWitnessDTO.MentalState ?? dbWitness.MentalState;
            dbWitness.Background = updateWitnessDTO.Background ?? dbWitness.Background;
            dbWitness.RelationToVictim = updateWitnessDTO.RelationToVictim ?? dbWitness.RelationToVictim;
            dbWitness.IsUnderObservation = updateWitnessDTO.IsUnderObservation ?? dbWitness.IsUnderObservation;
            dbWitness.IsSuspected = updateWitnessDTO.IsSuspected ?? dbWitness.IsSuspected;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Witness updated successfully!");
        }

        public async Task<ActionResult<string>> GetInfo(int id)
        {
            var dbWitness = await _context.Witnesses.FindAsync(id);
            return dbWitness == null
                ? "Witness does not exist!!"
                : $"Witness: Name -> " +
                dbWitness.Name + ", Occupation -> " + dbWitness.Profession + ", Residence -> " + dbWitness.Residence
                + ", " + "\nRelationship with the victim -> " + dbWitness.RelationToVictim + ", Under surveillance? "
                + dbWitness.IsUnderObservation + ", Is suspected? " + dbWitness.IsSuspected + ".";
        }

        //Here, the Facade Pattern is implemented

        //This method is responsible for moving a person from Witness to Suspect.
        public async Task<ActionResult> SaveAsSuspect(int id)
        {
            var d = await GetWitnessById(id);
            if (d is NotFoundObjectResult)
                return d;

            WitnessDTO? witness = ((OkObjectResult)d).Value as WitnessDTO;
            await SetSuspected(id);
            SuspectDTO suspect = ConvertToSuspect(witness);
            await AddToSuspects(suspect);
            return new OkObjectResult(suspect);
        }

        private async Task SetSuspected(int id)
        {
            var dbWitness = await _context.Witnesses.FindAsync(id);
            if (dbWitness == null)
                return;
            dbWitness.IsSuspected = true;
            await _context.SaveChangesAsync();
        }

        //This method is called from SaveAsSuspect to convert a witness to a suspect.
        private SuspectDTO ConvertToSuspect(WitnessDTO witness)
        {
            /*A new object of type ISuspectDTO is created 
             * and initialized with the same data as the witness,
             * only the suspicion will be changed later.             
             */
            SuspectDTO suspect = new()
            {
                Name = witness.Name,
                Gender = witness.Gender,
                Profession = witness.Profession,
                Status = witness.Status,
                Residence = witness.Residence,
                MentalState = witness.MentalState,
                Background= witness.Background,
                Suspicion = "Suspicion formulated in the meantime..."
            };

            return suspect;
        }

        //This method is called from SaveAsSuspect to add a suspect.
        private async Task AddToSuspects(SuspectDTO suspect)
        {
            /*
             * An instance of the ISuspectService class is created to use the AddToSuspects method
             * so that the same logic is not implemented in two different classes!
             */
            SuspectService s = new(_context, _mapper);
            await s.AddSuspect(suspect);
        }
    }
}
