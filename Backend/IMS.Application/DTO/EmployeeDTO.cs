using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTO
{
    public class EmployeeDTO 
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Email { get; set; }

        public int Devices { get; set; } = 0;

    }
}
