namespace HRSystem.Server.Models;

public  record DepartmentForManipulationDto
{
    public string DepartmentName { get; init; } = null!;

    public string? DepartmentDescription { get; init; }
}
