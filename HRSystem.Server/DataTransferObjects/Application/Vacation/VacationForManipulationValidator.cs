using FluentValidation;
using FluentValidation.Results;

namespace HRSystem.Server.DataTransferObjects.Application.Vacation;

public class VacationForManipulationValidator : AbstractValidator<VacationForManipulationDto>
{
    public VacationForManipulationValidator()
    {

        RuleFor(c => c.VacationDate)
            .NotEmpty();
        RuleFor(c => c.LeaveTypeId)
           .NotEmpty();

    }

    protected override bool PreValidate(ValidationContext<VacationForManipulationDto> context, ValidationResult result)
    {
        if (context.InstanceToValidate == null)
        {
            result.Errors.Add(new ValidationFailure("Creation Dto", "Please ensure a model was supplied."));
            return false;
        }
        return true;
    }
}
