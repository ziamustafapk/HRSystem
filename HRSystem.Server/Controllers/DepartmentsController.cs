using FluentValidation;
using FluentValidation.Results;
using HRSystem.Server.DataTransferObjects.Exceptions;
using HRSystem.Server.Models;
using HRSystem.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HRSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private IValidator<DepartmentForManipulationDto> _validator;

        public DepartmentsController(IServiceManager serviceManager, IValidator<DepartmentForManipulationDto> validator)
        {
            _serviceManager = serviceManager;
            _validator = validator;

        }
        [HttpGet("Version")]
        public ContentResult GetVersion()
            => Content("1.0");

        [HttpGet("Error")]
        public IActionResult GetError()
            => Problem("Something went wrong.");

        /// <summary>
        /// Gets the list of all Departments
        /// </summary>
        /// <returns>The Departments list</returns>
        [HttpGet(Name = "GetDepartments")]
        
        public async Task<IActionResult> GetDepartments()
        {

            var baseResult = await _serviceManager.DepartmentService.GetDepartmentsAsync(trackChanges: false);

            
            return Ok(baseResult);


        }
        /// <summary>
        /// Gets the Department by Id
        /// </summary>
        /// <returns>The Department</returns>
        [HttpGet("{id:int}", Name = "DepartmentById")]
        
        public async Task<IActionResult> GetDepartment(int id)
        {

            var baseResult = await _serviceManager.DepartmentService.GetDepartmentByIdAsync(id, trackChanges: false);
            
            return Ok(baseResult);
        }

        [HttpPost(Name = "CreateDepartment")]
       
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentForCreationDto departmentForCreationDto)
        {

            ValidationResult validationResult = await _validator.ValidateAsync(departmentForCreationDto);

            if (validationResult.Errors.Count > 0)
                throw new ValidationErrorsException(validationResult);

            var createdDepartment = await _serviceManager.DepartmentService.CreateDepartmentAsync(departmentForCreationDto, false);
            return CreatedAtRoute("DepartmentById", new { id = createdDepartment.DepartmentId }, createdDepartment);

        }


        [HttpPut("{id:int}")]
        
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentForUpdateDto department)
        {
            await _serviceManager.DepartmentService.UpdateDepartmentAsync(id, department, trackChanges: true);

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _serviceManager.DepartmentService.DeleteDepartmentAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetDepartmentsOptions()
        {
            Response.Headers.Append("Allow", "GET, OPTIONS, POST, PUT, DELETE");

            return Ok();
        }
    }

}
