using Company.Application.DTOs.ProjectEmployeeDTO;

namespace Company.Application.Abstractions.Services;

public interface IProjectEmployeeService
{
    Task<IEnumerable<ProjectEmployeeDTO>> GetAllAsync();
    Task<ProjectEmployeeDTO> GetByIdAsync(Guid projectId, Guid employeeId);
    Task<ProjectEmployeeDTO> CreateAsync(ProjectEmployeeDTO projectEmployee);
    Task UpdateAsync(Guid projectId, Guid employeeId, ProjectEmployeeDTO projectEmployee);
    Task DeleteAsync(Guid projectId, Guid employeeId);
}
