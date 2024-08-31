using HR_Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Persistence.Configurations.EntitiesConfig
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType()
                {
                    Id = 1,
                    DefaultDay = 10,
                    Name = "Jaunt",
                },
                new LeaveType()
                {
                    Id = 2,
                    DefaultDay = 3,
                    Name = "Disease",
                });
        }
    }
}
