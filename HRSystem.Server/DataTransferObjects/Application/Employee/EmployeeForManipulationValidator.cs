using FluentValidation;
using FluentValidation.Results;

namespace HRSystem.Server.DataTransferObjects.Application.Employee;

public class EmployeeForManipulationValidator : AbstractValidator<EmployeeForManipulationDto>
{
    public EmployeeForManipulationValidator()
    {

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .Length(2, 50).WithMessage($"The 'Employee First Name' should be between 3 to 50 character.");
        RuleFor(c => c.LastName)
            .NotEmpty()
            .Length(2, 50).WithMessage($"The 'Employee Last Name' should be between 3 to 50 character.");
        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress()
            .Length(2, 50).WithMessage($"The 'Email Address' should be between 3 to 50 character.");
        RuleFor(c => c.HireDate)
            .NotEmpty()
            .WithMessage($"The 'Hire Date' should be between 3 to 50 character.");
        RuleFor(c => c.BasicSalary)
            .NotEmpty()
            .WithMessage($"The 'BasicSalary' should not empty.");

    }

    protected override bool PreValidate(ValidationContext<EmployeeForManipulationDto> context, ValidationResult result)
    {
        if (context.InstanceToValidate == null)
        {
            result.Errors.Add(new ValidationFailure("Creation Dto", "Please ensure a model was supplied."));
            return false;
        }
        return true;
    }
}
