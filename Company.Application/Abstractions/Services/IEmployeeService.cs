using Company.Application.DTOs.EmployeeDTO;

namespace Company.Application.Abstractions.Services;

public interface IEmployeeService 
{
    Task<IEnumerable<EmployeeResponseDTO>> GetAllAsync();
    Task<EmployeeResponseDTO> GetByIdAsync(Guid id);
    Task<EmployeeResponseDTO> CreateAsync(EmployeeResponseDTO employee);
    Task UpdateAsync(Guid id, EmployeeResponseDTO employee);
    Task DeleteAsync(Guid id);
}
