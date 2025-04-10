using AutoMapper;
using Company.Application.DTOs;
using Company.Application.DTOs.DepartmentDTO;
using Company.Application.DTOs.EmployeeDTO;
using Company.Application.DTOs.ProjectDTO;
using Company.Application.DTOs.ProjectEmployeeDTO;
using Company.Domain.Entities;

namespace Company.Infrastructure;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Department, DepartmentRequestDTO>().ReverseMap();
        CreateMap<Department, DepartmentResponseDTO>().ReverseMap();
        CreateMap<Project, ProjectResponseDTO>().ReverseMap();
        CreateMap<Employee, EmployeeResponseDTO>().ReverseMap();
        CreateMap<ProjectEmployee, ProjectEmployeeDTO>().ReverseMap();
        CreateMap<Salary, SalaryDTO>().ReverseMap();
    }
}
