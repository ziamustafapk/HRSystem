using HRSystem.Server.DataAccess.DataContext;
using HRSystem.Server.DataAccess.Repositories.Generic;
using HRSystem.Server.Entities.Application;
namespace HRSystem.Server.DataAccess.Repositories.Application
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HrSystemDbContext hrSystemDbContext)
            : base(hrSystemDbContext)
        {
        }
    }

}
