using AutoMapper;
using Company.Application.Abstractions.Services;
using Company.Application.DTOs.SalaryDTO;
using Company.Domain.Entities;
using Company.Domain.Repositories;

namespace Company.Infrastructure.Services;

public class SalaryService : ServiceBase<Salary, SalaryResponseDTO, SalaryRequestDTO>, ISalaryService
{
    public SalaryService(IRepository<Salary> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public override Task DeleteAsync(Guid id)
    {
        throw new NotSupportedException("Deleting a salary is not allowed");  
    }
}
