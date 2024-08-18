using HRSystem.Server.DataAccess.DataContext;
using HRSystem.Server.DataAccess.Repositories.Generic;
using HRSystem.Server.Entities.Application;
namespace HRSystem.Server.DataAccess.Repositories.Application
{
    public class VacationRepository : RepositoryBase<Vacation>, IVacationRepository
    {
        public VacationRepository(HrSystemDbContext hrSystemDbContext)
            : base(hrSystemDbContext)
        {
        }
    }

}
