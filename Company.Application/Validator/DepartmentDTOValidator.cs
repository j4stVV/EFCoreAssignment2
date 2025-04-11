using Company.Application.DTOs.DepartmentDTO;
using FluentValidation;

namespace Company.Application.Validator;

public class DepartmentDTOValidator : AbstractValidator<DepartmentRequestDTO>
{
    public DepartmentDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
    }
} 