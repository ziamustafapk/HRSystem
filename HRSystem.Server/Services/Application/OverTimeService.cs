using AutoMapper;
using HRSystem.Server.DataAccess.Repositories;
using HRSystem.Server.DataTransferObjects.Application.Overtime;
using HRSystem.Server.Entities.Application;
using HRSystem.Server.Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Server.Services.Application;

internal sealed class OverTimeService : IOverTimeService
{
    private readonly IRepositoryManager _repository;

    private readonly IMapper _mapper;

    public OverTimeService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<OvertimeDto> CreateOverTimeForEmployeeAsync(int employeeId, OvertimeForCreationDto overtimeForCreationDto, bool trackChanges)
    {
         await GetEmployeeIfExists(employeeId, trackChanges);

        var entity = _mapper.Map<Overtime>(overtimeForCreationDto);
        entity.EmployeeId = employeeId;
        _repository.Overtime.Create(entity);
        await _repository.SaveAsync();
        var overtimeDto = _mapper.Map<OvertimeDto>(entity);
        return (overtimeDto);
    }

    private async Task GetEmployeeIfExists(int id, bool trackChanges)
    {
        var employee = await _repository.Employee
            .FindByCondition(d => d.EmployeeId.Equals(id), trackChanges)
            .FirstOrDefaultAsync();

        if (employee is null)
            throw new EntityNotFoundException(id, "Employee");

    }
}