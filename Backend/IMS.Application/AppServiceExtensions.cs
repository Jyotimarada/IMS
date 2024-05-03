using IMS.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAllApplicationService(this IServiceCollection services  )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<EmployeeService>();
            services.AddScoped<DeviceService>();

            return services;
        }
    }
}
