using FluentValidation;
using FluentValidation.Results;
using HRSystem.Server.DataTransferObjects.Application.Overtime;
using HRSystem.Server.DataTransferObjects.Exceptions;
using HRSystem.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Server.Controllers
{
    [Route("api/employees/{employeeId}/overtimes")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class OvertimesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IValidator<OvertimeForManipulationDto> _overtimeValidator;

        public OvertimesController(IServiceManager serviceManager

            , IValidator<OvertimeForManipulationDto> overtimevalidator
            )
        {
            _serviceManager = serviceManager;

            _overtimeValidator = overtimevalidator;

        }

        
        [HttpPost(Name = "CreateOverTimeForEmployee")]
        public async Task<IActionResult> CreateOverTimeForEmployee(int employeeId, [FromBody] OvertimeForCreationDto overtimeForCreationDto)
        {

            ValidationResult validationResult = await _overtimeValidator.ValidateAsync(overtimeForCreationDto);

            if (validationResult.Errors.Count > 0)
                throw new ValidationErrorsException(validationResult);

            var createdEmployee = await _serviceManager.OverTimeService.CreateOverTimeForEmployeeAsync(employeeId, overtimeForCreationDto, false);
            return CreatedAtRoute("EmployeeById", new { id = createdEmployee.EmployeeId }, createdEmployee);

        }

    }
}
