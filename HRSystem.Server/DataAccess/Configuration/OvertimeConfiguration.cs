using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRSystem.Server.Entities.Application;

namespace HRSystem.Server.DataAccess.Configuration
{
    public class OvertimeConfiguration : IEntityTypeConfiguration<Overtime>
    {
        public void Configure(EntityTypeBuilder<Overtime> builder)
        {
            builder.ToTable("Overtime");
            builder.HasKey(e => e.OvertimeId).HasName("PK_OvertimeID");



            builder.Property(e => e.OvertimeId).HasColumnName("OvertimeID");
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            builder.Property(e => e.OvertimeHours).HasColumnType("decimal(5, 2)");

            builder.HasOne(d => d.Employee).WithMany(p => p.Overtimes)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Overtime_Employees");


        }
    }

}
