namespace HRSystem.Server.Entities.Application;

public partial class Vacation
{
    public int VacationId { get; set; }

    public int? EmployeeId { get; set; }

    public int? LeaveTypeId { get; set; }

    public DateOnly VacationDate { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual LeaveType? LeaveType { get; set; }
}
