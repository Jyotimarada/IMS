using AutoMapper;
using IMS.Application.DTO;
using IMS.Application.Repositories;
using IMS.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace IMS.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMapper _mapper;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository repository, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = repository; 
            _mapper = mapper;
        }

        public async Task AddEmployee(EmployeeDTO employee, CancellationToken cancellationToken)
        {
            await _repository.Create(_mapper.Map<Employee>(employee));
            await _unitOfWork.Save(cancellationToken);
        }

        public async Task UpdateEmployee(EmployeeDTO employee, CancellationToken cancellationToken)
        {
                 _repository.Update(_mapper.Map<Employee>(employee));
            await _unitOfWork.Save(cancellationToken);
        }

        public async Task AssignDevices(int id, EmployeeDeviceDTO[] employeeDevices, CancellationToken cancellationToken=default)
        {
            await _repository.AssignDevices(id, _mapper.Map<EmployeeDevice[]>(employeeDevices), cancellationToken);
        }

        public List<EmployeeDTO> SearchByName(string searchString,CancellationToken cancellationToken = default)
        {
            return  _mapper.Map<List<EmployeeDTO>>(_repository.SearchEmplyeeByName(searchString, cancellationToken));
        }

        public async Task<EmployeeDTO> GetEmployee(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<EmployeeDTO>(await _repository.Get(id, cancellationToken));
        }

        public async Task<List<EmployeeDeviceDTO>> GetEmployeeDevices(int id)
        {
            return _mapper.Map<List<EmployeeDeviceDTO>>(await _repository.GetDevices(id));
            
        }
    }
}
