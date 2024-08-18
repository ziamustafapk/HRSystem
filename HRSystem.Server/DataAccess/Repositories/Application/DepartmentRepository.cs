using HRSystem.Server.DataAccess.DataContext;
using HRSystem.Server.DataAccess.Repositories.Generic;
using HRSystem.Server.Entities.Application;
namespace HRSystem.Server.DataAccess.Repositories.Application
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HrSystemDbContext hrSystemDbContext)
            : base(hrSystemDbContext)
        {
        }
    }

}
