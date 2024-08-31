using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole()
            {
                Id = "91FB45E9-606C-42FE-9ED6-5A145142DBDE",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            },
            new IdentityRole()
            {
                Id = "7A608EE8-37B6-4B15-8999-D0F421A558C6",
                Name = "Administration",
                NormalizedName = "ADMINISTRATION",
            }
            );
        }
    }
}
