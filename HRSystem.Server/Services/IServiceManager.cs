using HRSystem.Server.Services.Admin;
using HRSystem.Server.Services.Application;

namespace HRSystem.Server.Services
{
    public interface IServiceManager
    {

        IAuthenticationService AuthenticationService { get; }

        IDepartmentService DepartmentService { get; }
        IEmployeeService EmployeeService { get; }
        IOverTimeService OverTimeService { get; }
        IVacationService VacationService { get; }

        

    }


}
