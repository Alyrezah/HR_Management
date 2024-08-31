using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR_Management.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static void Configure(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
