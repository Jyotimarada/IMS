using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        IQueryable<Device> SearchDeviceByName(string searchString, CancellationToken cancellationToken);
    }
}
