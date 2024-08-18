using AutoMapper;
using HRSystem.Server.DataAccess.Repositories;
using HRSystem.Server.DataTransferObjects.Application.Employee;
using HRSystem.Server.Entities.Application;
using HRSystem.Server.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace HRSystem.Server.Services.Application
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(bool trackChanges)
        {
            var entities = await _repository.Employee.FindAll(trackChanges)
                  .Include(d => d.Overtimes)
                  .Include(d => d.Vacations)
                  .ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(entities);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id, bool trackChanges)
        {
            var employee = await GetEmployeeIfExists(id, trackChanges);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return (employeeDto);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreationDto employeeForCreationDto, bool trackChanges)
        {
            await GetEmployeeEmailDuplication(employeeForCreationDto.Email, false);
            var entity = _mapper.Map<Employee>(employeeForCreationDto);

            _repository.Employee.Create(entity);
            await _repository.SaveAsync();
            var employeeDto = _mapper.Map<EmployeeDto>(entity);
            return (employeeDto);
        }

       
        public async Task DeleteEmployeeAsync(int id, bool trackChanges)
        {
            var employee = await GetEmployeeIfExists(id, trackChanges);
            _repository.Employee.Delete(employee);
            await _repository.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeForUpdateDto employeeForUpdateDto, bool trackChanges)
        {
            var employee = await GetEmployeeIfExists(id, trackChanges);
            _mapper.Map(employeeForUpdateDto, employee);
            await _repository.SaveAsync();
        }

        private async Task<Employee> GetEmployeeIfExists(int id, bool trackChanges)
        {
            var employee = await _repository.Employee
                            .FindByCondition(d => d.EmployeeId.Equals(id), trackChanges)
                            .Include(d => d.Department)
                            .Include(d => d.Overtimes)
                            .Include(d => d.Vacations)
                            .FirstOrDefaultAsync();
            if (employee is null)
                throw new EntityNotFoundException(id, "Employee");

            return employee;
        }
        private async Task GetEmployeeEmailDuplication(string email, bool trackChanges)
        {
            var employee = await _repository.Employee
                            .FindByCondition(d => d.Email.ToLower().Equals(email.ToLower()), trackChanges)
                            .FirstOrDefaultAsync();
            if (employee is not null)
                throw new AlreadyExistException("Employee");

            
        }

    }

}
