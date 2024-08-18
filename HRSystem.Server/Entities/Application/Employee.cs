namespace HRSystem.Server.Entities.Application;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly HireDate { get; set; }

    public decimal BasicSalary { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Overtime> Overtimes { get; set; } = new List<Overtime>();

    public virtual ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
}
