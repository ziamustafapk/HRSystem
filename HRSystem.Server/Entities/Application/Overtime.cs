namespace HRSystem.Server.Entities.Application;

public partial class Overtime
{
    public int OvertimeId { get; set; }

    public int? EmployeeId { get; set; }

    public decimal OvertimeHours { get; set; }

    public DateOnly OvertimeDate { get; set; }

    public virtual Employee? Employee { get; set; }
}
