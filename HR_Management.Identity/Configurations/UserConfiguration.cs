using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser()
                {
                    Id = "79788D3F-CFB9-40CF-B4DE-00FEB61FDFD6",
                    FirstName = "Alireza",
                    LastName = "Heydari",
                    Email = "alireza80heydri@gmail.com",
                    NormalizedEmail = "ALIREZA80HEYDRI@GMAIL.COM",
                    EmailConfirmed = true,
                    UserName = "Alyrezaheydary",
                    NormalizedUserName = "ALYREZAHEYDARY",
                    PasswordHash = hasher.HashPassword(null, "Alirezasaina12#")
                },
                new ApplicationUser()
                {
                    Id = "FD7FC900-F1AD-4AA8-8C2F-6B082591CC8C",
                    FirstName = "FirstNameUser1",
                    LastName = "LastNameUser1",
                    Email = "user1@gmail.com",
                    NormalizedEmail = "USER1@GMAIL.COM",
                    EmailConfirmed = true,
                    UserName = "SystemUser1",
                    NormalizedUserName = "SYSTEMUSER1",
                    PasswordHash = hasher.HashPassword(null, "SystemUser1#")
                }
                );
        }
    }
}
