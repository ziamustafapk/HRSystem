using FluentValidation;
using FluentValidation.Results;
using HRSystem.Server.DataTransferObjects.Application.Vacation;
using HRSystem.Server.DataTransferObjects.Exceptions;
using HRSystem.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Server.Controllers
{
    [Route("api/employees/{employeeId}/vacations")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class VacationsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IValidator<VacationForManipulationDto> _vacationValidator;

        public VacationsController(IServiceManager serviceManager
            
            , IValidator<VacationForManipulationDto> vacationValidator
            )
        {
            _serviceManager = serviceManager;
            
            _vacationValidator = vacationValidator;

        }

        
        [HttpPost(Name = "CreateVacationForEmployee")]
        public async Task<IActionResult> CreateVacationForEmployee(int employeeId, [FromBody] VacationForCreationDto vacationForCreationDto)
        {

            ValidationResult validationResult = await _vacationValidator.ValidateAsync(vacationForCreationDto);

            if (validationResult.Errors.Count > 0)
                throw new ValidationErrorsException(validationResult);

            var createdEmployee = await _serviceManager.VacationService.CreateVacationForEmployeeAsync(employeeId, vacationForCreationDto, false);
            return CreatedAtRoute("EmployeeById", new { id = createdEmployee.EmployeeId }, createdEmployee);

        }

    }
}
