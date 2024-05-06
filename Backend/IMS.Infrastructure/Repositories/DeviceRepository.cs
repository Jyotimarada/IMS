using IMS.Application.Repositories;
using IMS.Domain.Entities;
using IMS.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(IMSDbContext context) : base(context)
        {
        }

        public IQueryable<Device> SearchDeviceByName(string searchString, bool availableDevices, CancellationToken cancellationToken)
        {
            if (availableDevices)
                return _context.Devices.FromSqlInterpolated<Device>($"SELECT DISTINCT  D.* FROM Device D LEFT JOIN EmployeeDevice ED ON D.Id = ED.DeviceId WHERE D.Name LIKE {"%" + searchString + "%"} AND (ED.AssignedDate IS NULL OR D.Shared = 1);");
            else
                return _context.Devices.Where(e => (searchString == null || e.Name.ToLower().Contains(searchString.ToLower())));
        }
    }
}