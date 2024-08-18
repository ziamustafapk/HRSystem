using HRSystem.Server.DataAccess.DataContext;
using HRSystem.Server.DataAccess.Repositories.Application;

namespace HRSystem.Server.DataAccess.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {


        private readonly HrSystemDbContext _hrSystemDbContext;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IOvertimeRepository> _overtimeRepository;

        private readonly Lazy<IVacationRepository> _vacationRepository;
        
        public RepositoryManager(HrSystemDbContext hrSystemDbContext)
        {

            _hrSystemDbContext = hrSystemDbContext;

            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(hrSystemDbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(hrSystemDbContext));
            _overtimeRepository = new Lazy<IOvertimeRepository>(() => new OvertimeRepository(hrSystemDbContext));
            _vacationRepository = new Lazy<IVacationRepository>(() => new VacationRepository(hrSystemDbContext));

         

        }
       
        public IDepartmentRepository Department => _departmentRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IOvertimeRepository Overtime => _overtimeRepository.Value;

        public IVacationRepository Vacation => _vacationRepository.Value;

        public async Task SaveAsync()
        {
           
            await _hrSystemDbContext.SaveChangesAsync();
        }

        
    }


}
