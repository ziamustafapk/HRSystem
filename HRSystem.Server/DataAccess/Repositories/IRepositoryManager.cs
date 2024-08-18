using HRSystem.Server.DataAccess.Repositories.Application;

namespace HRSystem.Server.DataAccess.Repositories
{
    public interface IRepositoryManager
    {

        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        IOvertimeRepository Overtime { get; }
        IVacationRepository Vacation { get; }
        Task SaveAsync();

    }


}
