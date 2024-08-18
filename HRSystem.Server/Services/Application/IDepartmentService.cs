using HRSystem.Server.Models;

namespace HRSystem.Server.Services.Application
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(bool trackChanges);
        Task<DepartmentDto> GetDepartmentByIdAsync(int id, bool trackChanges);
        Task<DepartmentDto> CreateDepartmentAsync(DepartmentForCreationDto departmentForCreationDto, bool trackChanges);
        Task DeleteDepartmentAsync(int id, bool trackChanges);
        Task UpdateDepartmentAsync(int id, DepartmentForUpdateDto departmentForUpdateDto, bool trackChanges);

    }
    

}
