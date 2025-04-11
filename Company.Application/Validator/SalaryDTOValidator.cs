using Company.Application.DTOs.SalaryDTO;
using Company.Domain.Repositories;
using FluentValidation;

namespace Company.Application.Validator;

public class SalaryDTOValidator : AbstractValidator<SalaryRequestDTO>
{
    private readonly IEmployeeRepository _employeeRepository;

    public SalaryDTOValidator(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;

        RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage("Employee ID is required.");
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");  
    }
}
