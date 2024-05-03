using IMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task AssignDevices(int id, EmployeeDevice[] devices, CancellationToken cancellationToken);

        Task<List<EmployeeDevice>> GetDevices(int EmployeeId);

        IQueryable<Employee> SearchEmplyeeByName(string searchString, CancellationToken cancellationToken);

    }
}
