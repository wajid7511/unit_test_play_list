using AutoMapper;
using GraphQl.Abstraction.Patients.Models;
using GraphQl.API.Models;
using GraphQl.DataBase.Models;

namespace GraphQl.Mappers;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<PatientDto, Patient>()
            .ForMember(m => m.Id, opt => opt.Ignore())
            .ForMember(m => m.CreatedOn, opt => opt.Ignore())
            .ForMember(m => m.LastUpdateTime, opt => opt.Ignore());

        CreateMap<Patient, PatientSchema>()
        .ForMember(m => m.CreationDateTime, opt => opt.MapFrom(src => src.CreatedOn))
        .ForAllMembers(opt => opt.ExplicitExpansion());
    }
}
