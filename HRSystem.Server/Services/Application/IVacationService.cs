using HRSystem.Server.DataTransferObjects.Application.Vacation;

namespace HRSystem.Server.Services.Application;

public interface IVacationService
{
       
    Task<VacationDto> CreateVacationForEmployeeAsync(int employeeId, VacationForCreationDto vacationForCreationDto, bool trackChanges);
       
}