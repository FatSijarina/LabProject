using Microsoft.AspNetCore.Mvc;

namespace CaseTrackingAPI.Services.Interfaces.PersonsInterfaces
{
    public interface IGetInfo
    {
        //Strategy Pattern
        /*
         * Kjo metodë përdoret nga klasat që e implementojnë interface-in
         * dhe përdoret ndryshe në verësi pse implementohet
         */
        public Task<ActionResult<string>> GetInfo(int id);
    }
}
