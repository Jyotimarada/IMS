using IMS.Application.DTO;
using IMS.Application.Repositories;
using IMS.Application.Services;
using IMS.Domain.Entities;
using IMS.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMS.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
       
        /// <summary>
        /// Employees Controller Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get all employees that matches the search string
        /// </summary>
        /// <param name="s">Search string</param>
        /// <returns>Employees that matches s </returns>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployees([FromQuery] string? s, CancellationToken cancellationToken)
        {
            return _employeeService.SearchByName(s,cancellationToken);
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<EmployeeDTO> GetEmployeeById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await _employeeService.GetEmployee(id,cancellationToken);
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee">Employee details to be added</param>
        /// <returns>response of the operation</returns>
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeDTO employee, CancellationToken cancellationToken)
        {
            await _employeeService.AddEmployee(employee, cancellationToken);

            return Ok(new { Message = "Employee created!" });
        }


        /// <summary>
        /// Update employee information
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <param name="employee">Employee details</param>
        /// <returns>Status of the operation</returns>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO employee, CancellationToken cancellationToken)
        {
            employee.Id = id;
            await _employeeService.UpdateEmployee(employee, cancellationToken);

            return Ok(new { Message = "Employee Updated!" });
        }

        /// <summary>
        /// Assign devices to employee
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <param name="employeeDevies">Devices to be assigned</param>
        /// <returns>Status of the operation</returns>
        [HttpPost]
        [Route("{id:int}/assign-devices")]
        public async Task<IActionResult> AssignDevice([FromRoute] int id, [FromBody] EmployeeDeviceDTO[] employeeDevies, CancellationToken cancellationToken)
        {
            await _employeeService.AssignDevices(id, employeeDevies);
            return Ok(new { Message = "Employee created!" });
        }


        /// <summary>
        /// Get employee devices by employee id
        /// </summary>
        /// <param name="id">id of the employee</param>
        /// <returns>List of employee with devices</returns>
        [HttpGet]
        [Route("{id:int}/devices")]
        public async Task<IEnumerable<EmployeeDeviceDTO>> GetEmployeeDevices([FromRoute] int id)
        {
            return await _employeeService.GetEmployeeDevices(id);

        }

    }
}
