using AutoMapper;
using HRSystem.Server.DataAccess.Repositories;
using HRSystem.Server.Entities.Admin;
using HRSystem.Server.Entities.Configuration;
using HRSystem.Server.Services.Admin;
using HRSystem.Server.Services.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace HRSystem.Server.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;

        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IOverTimeService> _overtimeService;
        private readonly Lazy<IVacationService> _vacationService;


        public ServiceManager(IRepositoryManager repositoryManager,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtConfiguration> configuration,
            IMapper mapper)
        {

            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(mapper, userManager, configuration));

            _departmentService = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, mapper));
            _overtimeService = new Lazy<IOverTimeService>(() => new OverTimeService(repositoryManager, mapper));
            _vacationService = new Lazy<IVacationService>(() => new VacationService(repositoryManager, mapper));
        }


        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IDepartmentService DepartmentService => _departmentService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;

        public IOverTimeService OverTimeService => _overtimeService.Value;

        public IVacationService VacationService => _vacationService.Value;
    }

}
