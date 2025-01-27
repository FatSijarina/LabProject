using CaseTrackingAPI.DTOs.PersonsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.PersonsInterfaces
{
    public interface IWitnessService
    {
        Task<ActionResult<List<WitnessDTO>>> GetWitnesses();
        Task<ActionResult> GetWitnessById(int id);
        Task<ActionResult<bool>> ISuspected(int id);
        Task<ActionResult<bool>> IsObserved(int id);
        Task<ActionResult> AddWitness(WitnessDTO witnessDTO);
        Task<ActionResult> UpdateWitness(int id, UpdateWitnessDTO updateWitnessDTO);
        Task<ActionResult<string>> GetInfo(int id);
        Task<ActionResult> SaveAsSuspect(int id);
    }
}
