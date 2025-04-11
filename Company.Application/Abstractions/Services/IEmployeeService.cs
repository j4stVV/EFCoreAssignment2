using Company.Application.DTOs.EmployeeDTO;
using Company.Domain.Entities;

namespace Company.Application.Abstractions.Services;

public interface IEmployeeService : IServiceBase<Employee, EmployeeResponseDTO, EmployeeRequestDTO>
{
    Task<IEnumerable<EmployeeWithDepartmentResponseDTO>> GetAllWithDepartmentAsync();
    Task<IEnumerable<EmployeeWithProjectsResponseDTO>> GetAllWithProjectsAsync();
    Task<IEnumerable<EmployeeWithSalaryResponseDTO>> GetEmployeesBySalaryAndJoinedDateAsync(decimal minSalary, DateOnly minJoinedDate);
}
