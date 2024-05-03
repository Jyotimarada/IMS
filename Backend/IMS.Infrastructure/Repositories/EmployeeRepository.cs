using IMS.Application.Repositories;
using IMS.Domain.Entities;
using IMS.Infrastructure.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly IDeviceRepository _deviceRepository;
        public EmployeeRepository(IMSDbContext context, IDeviceRepository deviceRepository) : base(context)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task AssignDevices(int id, EmployeeDevice[] devices, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.Where(e => e.Id == id).Include(b => b.Devices).FirstOrDefault();
            if (employee == null) { throw new HttpRequestException($"Employee with employee id {id} not found", null, System.Net.HttpStatusCode.NotFound); }
            { employee.Devices = employee.Devices ??  new List<Device>(); }

            var newDevices = _context.Devices.Where(d => devices.Select(ed => ed.DeviceId).Contains(d.Id));

            employee.Devices.AddRange(newDevices);
            _context.SaveChanges();

            foreach (var ed in devices) 
            {
                var employeeDevice = _context.EmployeeDevices.Where(e => e.EmployeeId == id && e.DeviceId == ed.DeviceId).FirstOrDefault();
                if (employeeDevice != null) 
                {
                    employeeDevice.AssignedDate = ed.AssignedDate;
                }
            }

            _context.SaveChanges();
        }

        public IQueryable<Employee> SearchEmplyeeByName(string searchString, CancellationToken cancellationToken)
        {
             return _context.Employees.Include(e => e.Devices).Where(e => searchString == null || e.FirstName.ToLower().Contains(searchString.ToLower()) || e.LastName.ToLower().Contains(searchString.ToLower()));
        }

        public async Task GetWithEmployeeDevices(int employeeId, CancellationToken cancellationToken)
        {
            await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId, cancellationToken);
        }

        private async Task<List<EmployeeDevice>> GetEmployeeDevices(int EmployeeId)
        {
            return await _context.EmployeeDevices.FromSql($"SELECT ED.* FROM Device D Inner JOIN EmployeeDevice ED ON D.Id = ED.DeviceId WHERE ED.EmployeeId = {EmployeeId}").ToListAsync();
        }

        public async Task<List<EmployeeDevice>> GetDevices(int EmployeeId)
        {
            return await _context.EmployeeDevices.FromSql($"SELECT ED.* FROM Device D Inner JOIN EmployeeDevice ED ON D.Id = ED.DeviceId WHERE ED.EmployeeId = {EmployeeId}")
                .Include(e => e.Employee)
                .Include(e => e.Device)
                .ToListAsync();
        }
    }
}
