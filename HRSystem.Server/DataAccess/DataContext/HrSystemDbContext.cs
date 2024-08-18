using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HRSystem.Server.Entities.Admin;
using HRSystem.Server.Entities.Application;

namespace HRSystem.Server.DataAccess.DataContext
{
    public class HrSystemDbContext : IdentityDbContext<ApplicationUser>
    {

        public HrSystemDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<LeaveType> LeaveTypes { get; set; }

        public virtual DbSet<Overtime> Overtimes { get; set; }

        public virtual DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
