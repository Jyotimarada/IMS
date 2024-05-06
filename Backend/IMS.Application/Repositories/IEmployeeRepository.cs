using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories
{
    /// <summary>
    /// Interface for EmployeeRepository.
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Addign devices to employee.
        /// </summary>
        /// <param name="id">Id of the employee.</param>
        /// <param name="devices">Devices to be assigned to the employee.</param>
        Task AssignDevices(int id, EmployeeDevice[] devices, CancellationToken cancellationToken);

        /// <summary>
        /// Get devices of the employee with id.
        /// </summary>
        /// <param name="EmployeeId">Id of the employee.</param>
        /// <returns>List of employee devices.</returns>
        Task<List<EmployeeDevice>> GetDevices(int EmployeeId);

        /// Get list of employees with name containing search string.
        /// </summary>
        /// <param name="searchString">searchString used for searching name of the employee.</param>
        /// <returns>List of employees.</returns>
        IQueryable<Employee> SearchEmplyeeByName(string searchString, CancellationToken cancellationToken);

    }
}
