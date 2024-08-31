using HR_Management.Application.Cantracts.Infrastructure;
using HR_Management.Application.Models;
using HR_Management.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Infrastructure
{
    public static class InfrastructureServicesRegisteration
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();
        }
    }
}
