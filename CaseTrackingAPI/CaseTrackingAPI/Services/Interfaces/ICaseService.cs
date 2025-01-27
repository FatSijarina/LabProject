using CaseTrackingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces
{
    public interface ICaseService
    {
        public Task<ActionResult<List<GetCasesDetailsDTO>>> GetCases();
        public Task<ActionResult<List<GetCaseDTO>>> GetCaseById(int id);
        public Task<ActionResult> AddCase(AddCaseDTO caseDTO);
        public Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO);
        public Task<ActionResult> DeleteCase(int id);
        public Task<ActionResult> ChangeCaseStatus(int id, string status);
    }
}