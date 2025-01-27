using CaseTrackingAPI.DTOs.PersonsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.PersonsInterfaces
{
    public interface IVictimService
    {
        Task<ActionResult<List<VictimDTO>>> GetVictims();

        Task<ActionResult> GetVictimById(int id);

        Task<ActionResult> AddVictim(VictimDTO victimDTO);

        Task<ActionResult> UpdateVictim(int id, UpdateVictimDTO updateVictimDTO);

        Task<ActionResult<string>> GetInfo(int id);
    }
}
