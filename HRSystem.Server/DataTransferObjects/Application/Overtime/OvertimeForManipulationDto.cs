namespace HRSystem.Server.DataTransferObjects.Application.Overtime;

public record OvertimeForManipulationDto
{
    

    public decimal OvertimeHours { get; init; }

    public DateOnly OvertimeDate { get; init; }

    
}
