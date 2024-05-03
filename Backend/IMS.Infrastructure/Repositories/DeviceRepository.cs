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

        public IQueryable<Device> SearchDeviceByName(string searchString, CancellationToken cancellationToken)
        {
            return _context.Devices.Where(d => searchString == null || d.Name.ToLower().Contains(searchString.ToLower()));
        }
    }
}
