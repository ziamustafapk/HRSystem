using HRSystem.Server.DataAccess.DataContext;
using HRSystem.Server.DataAccess.Repositories.Generic;
using HRSystem.Server.Entities.Application;
namespace HRSystem.Server.DataAccess.Repositories.Application
{
    public class OvertimeRepository : RepositoryBase<Overtime>, IOvertimeRepository
    {
        public OvertimeRepository(HrSystemDbContext hrSystemDbContext)
            : base(hrSystemDbContext)
        {
        }
    }

}
