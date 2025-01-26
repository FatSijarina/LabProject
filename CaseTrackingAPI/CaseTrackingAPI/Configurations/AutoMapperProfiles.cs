using AutoMapper;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.DTOs.EvidencesDTOs;
using CaseTrackingAPI.DTOs.PersonsDTOs;
using CaseTrackingAPI.Models;


namespace Detecto.API.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DCase, GetCaseDTO>().ReverseMap();
            CreateMap<DCase, GetCasesDetailsDTO>().ReverseMap();
            CreateMap<AddCaseDTO, DCase>();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Victim, VictimDTO>().ReverseMap();
            CreateMap<Witness, WitnessDTO>().ReverseMap();
            CreateMap<Suspect, SuspectDTO>().ReverseMap();
            CreateMap<Evidence, EvidenceDTO>().ReverseMap();
            CreateMap<BiologicalEvidence, BiologicalEvidenceDTO>().ReverseMap();
            CreateMap<PhysicalEvidence, PhysicalEvidenceDTO>().ReverseMap();
            CreateMap<BiologicalTrace, BiologicalTraceDTO>().ReverseMap();
            CreateMap<Statement, StatementDTO>().ReverseMap();
            CreateMap<DFile, FileDTO>().ReverseMap();
           // CreateMap<List<PNG>, List<CasePngDTO>>().ReverseMap();
        }
    }
}
