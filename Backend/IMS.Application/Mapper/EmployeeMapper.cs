using AutoMapper;
using IMS.Application.DTO;
using IMS.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Mapper
{
    public sealed class EmployeeMapper : Profile
    {
       public EmployeeMapper() 
        {
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>()
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.LastName}, {src.FirstName}"))
                .ForMember(dest => dest.Devices, opt => opt.MapFrom(src => src.Devices == null ? 0 : src.Devices.Count()));

            CreateMap<EmployeeDeviceDTO, EmployeeDevice>();
            CreateMap<EmployeeDevice, EmployeeDeviceDTO>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FirstName))
                .ForMember(dest => dest.Devicename, opt => opt.MapFrom(src => src.Device.Name));
            CreateMap<DeviceDTO, Device>();
            CreateMap<Device, DeviceDTO>();
        }
    }
}
