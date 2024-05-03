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

        public DeviceService(ILogger<DeviceService> logger, IDeviceRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public List<DeviceDTO> SearchByName(string searchString, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<List<DeviceDTO>>(_repository.SearchDeviceByName(searchString, cancellationToken));
        }

        public async Task<DeviceDTO> GetDevice(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<DeviceDTO>(await _repository.Get(id, cancellationToken));
        }

        public async Task AddDevice(DeviceDTO device, CancellationToken cancellationToken)
        {
            await _repository.Create(_mapper.Map<Device>(device));
            await _unitOfWork.Save(cancellationToken);
        }

        public async Task UpdateDevice(DeviceDTO employee, CancellationToken cancellationToken)
        {
            _repository.Update(_mapper.Map<Device>(employee));
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
