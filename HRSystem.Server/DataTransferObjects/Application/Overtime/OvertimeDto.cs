namespace HRSystem.Server.DataTransferObjects.Application.Overtime;

public  record OvertimeDto
{
    public int OvertimeId { get; init; }

    public int? EmployeeId { get; init; }

    public decimal OvertimeHours { get; init; }

    public DateOnly OvertimeDate { get; init; }

}
