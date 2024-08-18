using HRSystem.Server.DataTransferObjects.Application.Employee;

namespace HRSystem.Server.Services.Application
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(bool trackChanges);
        Task<EmployeeDto> GetEmployeeByIdAsync(int id, bool trackChanges);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreationDto employeeForCreationDto, bool trackChanges);
        Task DeleteEmployeeAsync(int id, bool trackChanges);
        Task UpdateEmployeeAsync(int id, EmployeeForUpdateDto employeeForUpdateDto, bool trackChanges);

     
    }
}
