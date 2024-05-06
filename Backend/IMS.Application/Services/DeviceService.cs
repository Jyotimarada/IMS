using AutoMapper;
using IMS.Application.DTO;
using IMS.Application.Repositories;
using IMS.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Services
{
    public class DeviceService
    {
        private readonly IDeviceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeviceService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceService"/> class.
        /// </summary>
        /// <param name="logger">logger.</param>
        /// <param name="repository">DeviceRepository.</param>
        /// <param name="IUnitOfWork">UnitOfWork.</param>
        /// <param name="mapper">mapper.</param>
        public DeviceService(ILogger<DeviceService> logger, IDeviceRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Search device by name .
        /// </summary>
        public List<DeviceDTO> SearchByName(string searchString, bool availableDevices, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<List<DeviceDTO>>(_repository.SearchDeviceByName(searchString, availableDevices, cancellationToken));
        }

        /// <summary>
        /// Get device by id.
        /// </summary>
        public async Task<DeviceDTO> GetDevice(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<DeviceDTO>(await _repository.Get(id, cancellationToken));
        }

        /// <summary>
        /// Add device.
        /// </summary>
        public async Task AddDevice(DeviceDTO device, CancellationToken cancellationToken)
        {
            await _repository.Create(_mapper.Map<Device>(device));
            await _unitOfWork.Save(cancellationToken);
        }

        /// <summary>
        /// Update device.
        /// </summary>
        public async Task UpdateDevice(DeviceDTO employee, CancellationToken cancellationToken)
        {
            _repository.Update(_mapper.Map<Device>(employee));
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
