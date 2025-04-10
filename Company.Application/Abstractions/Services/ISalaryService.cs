using Company.Application.DTOs;

namespace Company.Application.Abstractions.Services;

public interface ISalaryService
{
    Task<IEnumerable<SalaryDTO>> GetAllAsync();
    Task<SalaryDTO> GetByIdAsync(Guid id);
    Task<SalaryDTO> CreateAsync(SalaryDTO salary);
    Task UpdateAsync(Guid id, SalaryDTO salary);
    Task DeleteAsync(Guid id);
}
