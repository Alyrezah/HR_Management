using HR_Management.Application.Cantracts.Persistence;
using HR_Management.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Persistence
{
    public static class PersistenceServicesRegisteration
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HRManagementConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        }
    }
}
