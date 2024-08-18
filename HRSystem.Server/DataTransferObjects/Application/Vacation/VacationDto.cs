using HRSystem.Server.DataTransferObjects.Application.LeaveType;

namespace HRSystem.Server.DataTransferObjects.Application.Vacation;

public  record VacationDto
{
    public int VacationId { get; init; }

    public int? EmployeeId { get; init; }

    public int? LeaveTypeId { get; init; }

    public DateOnly VacationDate { get; init; }

    public virtual LeaveTypeDto? LeaveType { get; init; }
}
