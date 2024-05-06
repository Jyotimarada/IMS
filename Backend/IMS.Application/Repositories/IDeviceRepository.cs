using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories
{
    /// <summary>
    /// Interface for DeviceRepository.
    /// </summary>
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        /// <summary>
        /// Searches for devices with name containing searchString.
        /// </summary>
        IQueryable<Device> SearchDeviceByName(string searchString, bool availableDevices, CancellationToken cancellationToken);
    }
}
