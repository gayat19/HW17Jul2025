using AutoMapper;


using FirstAPI.Models;
using FirstAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

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

            CreateMap<Department, GetDepartmnetsDTO>();
            CreateMap<GetDepartmnetsDTO,Department>();

            CreateMap<EmployeeStatusMaster,EmployeeStatusDTO>();
            CreateMap<EmployeeStatusDTO,EmployeeStatusMaster >();

            CreateMap<LoginResponseDTO, User>();
            CreateMap< User, LoginResponseDTO>();


            CreateMap<Employee, AddEmployeeRequestDTO>();
            CreateMap<AddEmployeeRequestDTO,Employee >();

            CreateMap<AddEmployeeRequestDTO, User>();
            CreateMap<User,AddEmployeeRequestDTO>();

     
        }
    }
}
