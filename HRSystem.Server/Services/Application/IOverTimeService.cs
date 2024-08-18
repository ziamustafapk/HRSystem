using HRSystem.Server.DataTransferObjects.Application.Overtime;

namespace HRSystem.Server.Services.Application;

public interface IOverTimeService
{
       
        
    Task<OvertimeDto> CreateOverTimeForEmployeeAsync(int employeeId, OvertimeForCreationDto overtimeForCreationDto, bool trackChanges);

}