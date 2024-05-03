using IMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.DTO
{
    public class DeviceDTO 
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Barcode { get; set; }

        public bool Shared {  get; set; }    

        public DeviceType Type { get; set; }

    }
}
