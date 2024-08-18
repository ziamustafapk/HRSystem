namespace HRSystem.Server.DataTransferObjects.Application.Vacation;

public record VacationForManipulationDto
{
    

    public int? LeaveTypeId { get; init; }

    public DateOnly VacationDate { get; init; }

    
}
