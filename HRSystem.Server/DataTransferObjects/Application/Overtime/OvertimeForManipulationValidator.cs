using FluentValidation;
using FluentValidation.Results;

namespace HRSystem.Server.DataTransferObjects.Application.Overtime;

public class OvertimeForManipulationValidator : AbstractValidator<OvertimeForManipulationDto>
{
    public OvertimeForManipulationValidator()
    {

        RuleFor(c => c.OvertimeHours)
            .NotEmpty();
        RuleFor(c => c.OvertimeDate)
           .NotEmpty();

    }

    protected override bool PreValidate(ValidationContext<OvertimeForManipulationDto> context, ValidationResult result)
    {
        if (context.InstanceToValidate == null)
        {
            result.Errors.Add(new ValidationFailure("Creation Dto", "Please ensure a model was supplied."));
            return false;
        }
        return true;
    }
}
