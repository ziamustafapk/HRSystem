using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRSystem.Server.Entities.Application;

namespace HRSystem.Server.DataAccess.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(e => e.DepartmentId).HasName("PK_DepartmentID");

            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            builder.Property(e => e.DepartmentDescription).HasMaxLength(255);
            builder.Property(e => e.DepartmentName).HasMaxLength(100);


        }
    }

}
