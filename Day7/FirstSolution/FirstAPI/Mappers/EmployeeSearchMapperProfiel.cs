using AutoMapper;


using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Mappers
{

    public   class EmployeeSearchMapperProfile :Profile
    {
        public EmployeeSearchMapperProfile()
        {
            CreateMap<Employee, EmployeeSerachResponseDTO>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber));
            CreateMap< EmployeeSerachResponseDTO,Employee>()
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone));
        }
    }
}
