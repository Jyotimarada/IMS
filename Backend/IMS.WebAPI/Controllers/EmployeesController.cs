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
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployees([FromQuery] string? s, CancellationToken cancellationToken)
        {
            return _employeeService.SearchByName(s,cancellationToken);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<EmployeeDTO> GetEmployeeById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await _employeeService.GetEmployee(id,cancellationToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeDTO employee, CancellationToken cancellationToken)
        {
            await _employeeService.AddEmployee(employee, cancellationToken);

            return Ok(new { Message = "Employee created!" });
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] EmployeeDTO employee, CancellationToken cancellationToken)
        {
            employee.Id = id;
            await _employeeService.UpdateEmployee(employee, cancellationToken);

            return Ok(new { Message = "Employee Updated!" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}/assign-devices")]
        public async Task<IActionResult> AssignDevice([FromRoute] int id, [FromBody] EmployeeDeviceDTO[] employeeDevies, CancellationToken cancellationToken)
        {
            await _employeeService.AssignDevices(id, employeeDevies);
            return Ok(new { Message = "Employee created!" });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/devices")]
        public async Task<IEnumerable<EmployeeDeviceDTO>> GetEmployeeDevices([FromRoute] int id)
        {
            return await _employeeService.GetEmployeeDevices(id);
            //return await _repository.GetEmployeeDevices(id);


        }

    }
}
