using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRSystem.Server.Entities.Application;

namespace HRSystem.Server.DataAccess.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.EmployeeId).HasName("PK_EmployeeID");

            builder.HasIndex(e => e.Email, "UQ_Employees_Email").IsUnique();

            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            builder.Property(e => e.BasicSalary).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            builder.Property(e => e.Email).HasMaxLength(255);
            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);
            builder.Property(e => e.PhoneNumber).HasMaxLength(15);

            builder.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Employees_Deparments");


        }
    }

}
