using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IMS.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using IMS.Application.Repositories;
using IMS.Infrastructure.Repositories;

namespace IMS.Infrastructure
{
    public static class AppServiceExtensions
    {
        public static void ConfitureDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sqlite");
            services.AddDbContext<IMSDbContext>(options => options.UseSqlite(connectionString).EnableSensitiveDataLogging(true));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();

        }

    }
}
