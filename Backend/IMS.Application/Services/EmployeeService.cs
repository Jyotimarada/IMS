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

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="logger">logger.</param>
        /// <param name="repository">EmployeeRepository.</param>
        /// <param name="IUnitOfWork">UnitOfWork.</param>
        /// <param name="mapper">mapper.</param>
        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository repository, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = repository; 
            _mapper = mapper;
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee">Employee details to be added</param>
        /// <returns>response of the operation</returns>
        public async Task AddEmployee(EmployeeDTO employee, CancellationToken cancellationToken)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            await _repository.Create(_mapper.Map<Employee>(employee));
            await _unitOfWork.Save(cancellationToken);
        }

        /// <summary>
        /// Update employee information
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <param name="employee">Employee details</param>
        /// <returns>Status of the operation</returns>
        public async Task UpdateEmployee(EmployeeDTO employee, CancellationToken cancellationToken)
        {
            _repository.Update(_mapper.Map<Employee>(employee));
            await _unitOfWork.Save(cancellationToken);
        }

        /// <summary>
        /// Assign devices to employee.
        /// </summary>
        /// <param name="id">id of the employee.</param>
        /// <param name="employeeDevices">devices to be assigned.</param>
        public async Task AssignDevices(int id, EmployeeDeviceDTO[] employeeDevices, CancellationToken cancellationToken=default)
        {
            await _repository.AssignDevices(id, _mapper.Map<EmployeeDevice[]>(employeeDevices), cancellationToken);
        }

        public List<EmployeeDTO> SearchByName(string searchString,CancellationToken cancellationToken = default)
        {
            return  _mapper.Map<List<EmployeeDTO>>(_repository.SearchEmplyeeByName(searchString, cancellationToken));
        }

        /// <summary>
        /// Get employee with id
        /// </summary>
        /// <param name="id">id of the employee</param>
        /// <returns>Employee details </returns>
        public async Task<EmployeeDTO> GetEmployee(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<EmployeeDTO>(await _repository.Get(id, cancellationToken));
        }

        /// <summary>
        /// Get employee devices by employee id
        /// </summary>
        /// <param name="id">id of the employee</param>
        /// <returns>List of employee with devices</returns>
        public async Task<List<EmployeeDeviceDTO>> GetEmployeeDevices(int id)
        {
            return _mapper.Map<List<EmployeeDeviceDTO>>(await _repository.GetDevices(id));
            
        }
    }
}
