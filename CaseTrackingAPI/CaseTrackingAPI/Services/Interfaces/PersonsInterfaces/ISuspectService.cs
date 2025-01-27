using CaseTrackingAPI.DTOs.PersonsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.PersonsInterfaces
{
    public interface ISuspectService
    {
        Task<ActionResult<List<SuspectDTO>>> GetSuspects();

        Task<ActionResult> GetSuspectById(int id);

        Task<ActionResult<string>> GetSuspicionOnSuspect(int id);

        Task<ActionResult> AddSuspect(SuspectDTO suspectDto);

        Task<ActionResult> UpdateSuspect(int id, UpdateSuspectDTO updateSuspectDto);

        Task<ActionResult<string>> GetInfo(int id);

    }
}
