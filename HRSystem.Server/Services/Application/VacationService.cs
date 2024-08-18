using AutoMapper;
using HRSystem.Server.DataAccess.Repositories;
using HRSystem.Server.DataTransferObjects.Application.Vacation;
using HRSystem.Server.Entities.Application;
using HRSystem.Server.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Server.Services.Application;

internal sealed class VacationService : IVacationService
{
    private readonly IRepositoryManager _repository;

    private readonly IMapper _mapper;

    public VacationService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

   
    public async Task<VacationDto> CreateVacationForEmployeeAsync(int employeeId, VacationForCreationDto vacationForCreationDto, bool trackChanges)
    {
        var employee = await GetEmployeeIfExists(employeeId, trackChanges);
        var entity = _mapper.Map<Vacation>(vacationForCreationDto);
        entity.EmployeeId = employeeId;
        _repository.Vacation.Create(entity);
        await _repository.SaveAsync();
        var vacationDto = _mapper.Map<VacationDto>(entity);
        return (vacationDto);
    }

    private async Task<Employee> GetEmployeeIfExists(int id, bool trackChanges)
    {
        var employee = await _repository.Employee
            .FindByCondition(d => d.EmployeeId.Equals(id), trackChanges)
            .FirstOrDefaultAsync();
        if (employee is null)
            throw new EntityNotFoundException(id, "Employee");

        return employee;
    }
}