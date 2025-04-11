using AutoMapper;
using Company.Application.Abstractions.Services;
using Company.Application.DTOs.DepartmentDTO;
using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Infrastructure.Services;

public class DepartmentService : ServiceBase<Department, DepartmentResponseDTO, DepartmentRequestDTO>, IDepartmentService
{
    public DepartmentService(IRepository<Department> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}