using AutoMapper;
using Company.Application.DTOs.DepartmentDTO;
using Company.Application.DTOs.EmployeeDTO;
using Company.Application.DTOs.ProjectDTO;
using Company.Application.DTOs.ProjectEmployeeDTO;
using Company.Application.DTOs.SalaryDTO;
using Company.Domain.Entities;

namespace Company.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Department
        CreateMap<Department, DepartmentRequestDTO>().ReverseMap();
        CreateMap<Department, DepartmentResponseDTO>().ReverseMap();

        //Project
        CreateMap<Project, ProjectResponseDTO>().ReverseMap();
        CreateMap<Project, ProjectRequestDTO>().ReverseMap();
        //Employee
        CreateMap<Employee, EmployeeResponseDTO>().ReverseMap();
        CreateMap<Employee, EmployeeRequestDTO>().ReverseMap();

        //ProjectEmployee
        CreateMap<ProjectEmployee, ProjectEmployeeDTO>().ReverseMap();

        //Salary
        CreateMap<Salary, SalaryResponseDTO>().ReverseMap();
        CreateMap<Salary, SalaryRequestDTO>().ReverseMap();
    }
}
