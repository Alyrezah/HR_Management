using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "7A608EE8-37B6-4B15-8999-D0F421A558C6",
                    UserId = "79788D3F-CFB9-40CF-B4DE-00FEB61FDFD6"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "91FB45E9-606C-42FE-9ED6-5A145142DBDE",
                    UserId = "FD7FC900-F1AD-4AA8-8C2F-6B082591CC8C"
                }
                );
        }
    }
}
