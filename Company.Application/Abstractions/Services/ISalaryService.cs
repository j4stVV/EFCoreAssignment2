using Company.Application.DTOs.SalaryDTO;
using Company.Domain.Entities;

namespace Company.Application.Abstractions.Services;

public interface ISalaryService : IServiceBase<Salary, SalaryResponseDTO, SalaryRequestDTO>
{
}
