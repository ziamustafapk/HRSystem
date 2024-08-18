namespace HRSystem.Server.Models;

public  record DepartmentDto
{
    public int DepartmentId { get; init; }

    public string DepartmentName { get; init; } = null!;

    public string? DepartmentDescription { get; init; }

    
}
