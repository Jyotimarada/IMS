using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTO
{
    public class EmployeeDeviceDTO
    {
        [SwaggerSchema(ReadOnly = true)]
        public int EmployeeId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? EmployeeName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Devicename { get; set; }

        public int DeviceId { get; set; }

        public DateTimeOffset AssignedDate { get; set; }

        public DateTimeOffset ReturnDate { get; set; }

    }
}
