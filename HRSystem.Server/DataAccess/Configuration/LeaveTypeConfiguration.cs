using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRSystem.Server.Entities.Application;

namespace HRSystem.Server.DataAccess.Configuration
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.ToTable("LeaveTypes");
            builder.HasKey(e => e.LeaveTypeId).HasName("PK_LeaveTypeID");

            builder.Property(e => e.LeaveTypeId).HasColumnName("LeaveTypeID");
            builder.Property(e => e.LeaveName).HasMaxLength(100);


        }
    }

}
