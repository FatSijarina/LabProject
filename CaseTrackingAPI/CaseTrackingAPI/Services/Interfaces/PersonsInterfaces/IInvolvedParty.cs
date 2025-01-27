using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.PersonsInterfaces
{
    public interface IInvolvedParty
    {
        Task<ActionResult> DeletePerson(int id);

        Task<ICollection<WitnessDTO>> GetWitnesses(int caseId);

        Task<ICollection<SuspectDTO>> GetSuspects(int caseId);

        Task<ICollection<VictimDTO>> GetVictims(int caseId);
    }
}