using AutoMapper;
using HRSystem.Server.DataTransferObjects.Admin;
using HRSystem.Server.DataTransferObjects.Application.Employee;
using HRSystem.Server.DataTransferObjects.Application.Overtime;
using HRSystem.Server.DataTransferObjects.Application.Vacation;
using HRSystem.Server.Entities.Admin;
using HRSystem.Server.Entities.Application;
using HRSystem.Server.Models;


namespace HRSystem.Server.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserForRegistrationDto>().ReverseMap();



            // Department
            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, DepartmentForCreationDto>().ReverseMap();
            CreateMap<DepartmentForUpdateDto, Department>();
            CreateMap<DepartmentForUpdateDto, Department>().ReverseMap();
            // Employee
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeForCreationDto>().ReverseMap();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            // Overtime
            CreateMap<Overtime, OvertimeDto>();
            CreateMap<Overtime, OvertimeForCreationDto>().ReverseMap();
            CreateMap<OvertimeForUpdateDto, Overtime>().ReverseMap();
            // Overtime
            CreateMap<Vacation, VacationDto>();
            CreateMap<Vacation, VacationForCreationDto>().ReverseMap();
            CreateMap<VacationForUpdateDto, Vacation>().ReverseMap();

            

        }
    }
}
