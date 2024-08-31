using HR_Management.Application.Cantracts.Identity;
using HR_Management.Application.Models.Identity;
using HR_Management.Identity.Models;
using HR_Management.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Identity
{
    public static class IdentityServicesRegisteration
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));

            services.AddDbContext<HRManagementIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HRManagementIdentityConnectionString"),
                    x => x.MigrationsAssembly(typeof(HRManagementIdentityDbContext).Assembly.FullName)
                    );

            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HRManagementIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSetting:Issuer"],
                    ValidAudience = configuration["JwtSetting:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"]))
                };
            });
        }
    }
}
