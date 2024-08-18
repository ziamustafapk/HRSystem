using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRSystem.Server.Entities.Application;

namespace HRSystem.Server.DataAccess.Configuration
{
    public class VacationConfiguration : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.ToTable("Vacations");
            builder.HasKey(e => e.VacationId).HasName("PK_VacationID");

            builder.Property(e => e.VacationId).HasColumnName("VacationID");
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            builder.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");

            builder.HasOne(d => d.Employee).WithMany(p => p.Vacations)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Vacations_Employees");

            builder.HasOne(d => d.LeaveType).WithMany(p => p.Vacations)
                .HasForeignKey(d => d.LeaveTypeId)
                .HasConstraintName("FK_Vacations_LeaveTypes");


        }
    }

}
