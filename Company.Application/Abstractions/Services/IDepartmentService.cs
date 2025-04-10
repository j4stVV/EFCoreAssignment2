using Company.Application.DTOs.DepartmentDTO;
using Company.Domain.Entities;

namespace Company.Application.Abstractions.Services;

public interface IDepartmentService : IServiceBase<Department, DepartmentResponseDTO, DepartmentRequestDTO>
{
}
