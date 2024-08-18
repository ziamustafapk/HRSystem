using FluentValidation;
using FluentValidation.Results;

namespace HRSystem.Server.Models;

public class DepartmentForManipulationValidator : AbstractValidator<DepartmentForManipulationDto>
{
    public DepartmentForManipulationValidator()
    {

        RuleFor(c => c.DepartmentName)
            .NotEmpty()
            .Length(2, 50).WithMessage($"The 'Department Name' should be between 3 to 50 character.");
        
    }

    protected override bool PreValidate(ValidationContext<DepartmentForManipulationDto> context, ValidationResult result)
    {
        if (context.InstanceToValidate == null)
        {
            result.Errors.Add(new ValidationFailure("Creation Dto", "Please ensure a model was supplied."));
            return false;
        }
        return true;
    } 
    
   
}
