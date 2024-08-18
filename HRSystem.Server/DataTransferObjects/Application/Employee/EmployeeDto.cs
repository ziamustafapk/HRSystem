using HRSystem.Server.DataTransferObjects.Application.Overtime;
using HRSystem.Server.DataTransferObjects.Application.Vacation;
using HRSystem.Server.Models;

namespace HRSystem.Server.DataTransferObjects.Application.Employee;

public  record EmployeeDto
{
    public int EmployeeId { get; init; }

    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string Email { get; init; } = null!;

    public string? PhoneNumber { get; init; }

    public DateOnly HireDate { get; init; }

    public decimal BasicSalary { get; init; }

    public int? DepartmentId { get; init; }

    public  DepartmentDto? Department { get; init; }

    public  ICollection<OvertimeDto> Overtimes { get; init; } = new List<OvertimeDto>();

    public  ICollection<VacationDto> Vacations { get; init; } = new List<VacationDto>();
}
