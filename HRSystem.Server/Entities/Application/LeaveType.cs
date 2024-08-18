namespace HRSystem.Server.Entities.Application;

public partial class LeaveType
{
    public int LeaveTypeId { get; set; }

    public string LeaveName { get; set; } = null!;

    public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
}
