using Company.Application.DTOs.EmployeeDTO;
using Company.Domain.Repositories;
using FluentValidation;

namespace Company.Application.Validator;

public class EmployeeDTOValidator : AbstractValidator<EmployeeRequestDTO>
{
    private readonly IDepartmentRepository _departmentRepository;
    public EmployeeDTOValidator(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
        RuleFor(x => x.JoinedDate)
            .NotEmpty()
            .WithMessage("Joined date is required.")
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
            .WithMessage("Joined date cannot be in the future.");
        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("Department ID is required.");
    }
}
