using AutoMapper;
using HRSystem.Server.DataAccess.Repositories;
using HRSystem.Server.Entities.Application;
using HRSystem.Server.Entities.Exceptions;
using HRSystem.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace HRSystem.Server.Services.Application
{
    internal sealed class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _repository;
        
        private readonly IMapper _mapper;

        public DepartmentService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(bool trackChanges)
        {
          var entities = await _repository.Department.FindAll(trackChanges)
                .Include(d => d.Employees)
                .ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(entities);
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id, bool trackChanges)
        {
            var department = await GetDepartmentIfExists(id, trackChanges);

                var departmentDto = _mapper.Map<DepartmentDto>(department);
                return (departmentDto);
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(DepartmentForCreationDto departmentForCreationDto, bool trackChanges)
        {
            var entity = _mapper.Map<Department>(departmentForCreationDto);
                
                 _repository.Department.Create(entity);
                await _repository.SaveAsync();
            var departmentDto = _mapper.Map<DepartmentDto>(entity);
            return (departmentDto);
        }

        public async Task DeleteDepartmentAsync(int id, bool trackChanges)
        {
            var department = await GetDepartmentIfExists(id, trackChanges);
           _repository.Department.Delete(department);
            await _repository.SaveAsync();
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentForUpdateDto departmentForUpdateDto, bool trackChanges)
        {
            var department = await GetDepartmentIfExists(id, trackChanges);
            _mapper.Map(departmentForUpdateDto, department);
            await _repository.SaveAsync();
        }

        private async Task<Department> GetDepartmentIfExists(int id, bool trackChanges)
        {
            var department = await _repository.Department
                            .FindByCondition(d => d.DepartmentId.Equals(id), trackChanges)
                            .Include(d => d.Employees)
                            .FirstOrDefaultAsync();
            if (department is null)
                throw new EntityNotFoundException(id, "Department");

            return department;
        }

    }
}
