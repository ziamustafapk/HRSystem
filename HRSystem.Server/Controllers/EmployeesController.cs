using FluentValidation;
using FluentValidation.Results;
using HRSystem.Server.DataTransferObjects.Application.Employee;
using HRSystem.Server.DataTransferObjects.Exceptions;
using HRSystem.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class EmployeesController : ControllerBase
    
    {
        private readonly IServiceManager _serviceManager;
        private IValidator<EmployeeForManipulationDto> _validator;
        
        

        public EmployeesController(IServiceManager serviceManager
            , IValidator<EmployeeForManipulationDto> validator
            
           
            )
        {
            _serviceManager = serviceManager;
            _validator = validator;
           
           

        }
        

        /// <summary>
        /// Gets the list of all Employees
        /// </summary>
        /// <returns>The Employees list</returns>
        [HttpGet(Name = "GetEmployees")]

        public async Task<IActionResult> GetEmployees()
        {
            var baseResult = await _serviceManager.EmployeeService.GetEmployeesAsync(trackChanges: false);
            return Ok(baseResult);

        }
        /// <summary>
        /// Gets the Employee by Id
        /// </summary>
        /// <returns>The Employee</returns>
        [HttpGet("{id:int}", Name = "EmployeeById")]

        public async Task<IActionResult> GetEmployee(int id)
        {

            var baseResult = await _serviceManager.EmployeeService.GetEmployeeByIdAsync(id, trackChanges: false);

            return Ok(baseResult);
        }

        [HttpPost(Name = "CreateEmployee")]

        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreationDto employeeForCreationDto)
        {

            ValidationResult validationResult = await _validator.ValidateAsync(employeeForCreationDto);

            if (validationResult.Errors.Count > 0)
                throw new ValidationErrorsException(validationResult);

            var createdEmployee = await _serviceManager.EmployeeService.CreateEmployeeAsync(employeeForCreationDto, false);
            return CreatedAtRoute("EmployeeById", new { id = createdEmployee.EmployeeId }, createdEmployee);

        }
        

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            await _serviceManager.EmployeeService.UpdateEmployeeAsync(id, employeeForUpdateDto, trackChanges: true);

            return NoContent();
        }
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _serviceManager.EmployeeService.DeleteEmployeeAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetEmployeesOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS, POST, PUT, DELETE");

            return Ok();
        }
    }

}
