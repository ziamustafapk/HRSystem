namespace HRSystem.Server.DataTransferObjects.Application.Employee;

public record EmployeeForManipulationDto
{
    public string FirstName { get; init; } = null!;

    public string LastName { get; init; } = null!;

    public string Email { get; init; } = null!;

    public string? PhoneNumber { get; init; }

    public DateOnly HireDate { get; init; }

    public decimal BasicSalary { get; init; }

    public int? DepartmentId { get; init; }
}
