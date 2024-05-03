using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class Device : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "varchar(400)")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "Text")]
        public string? Description { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public DeviceType Type { get; set; } = DeviceType.Unknown;

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "Varchar(8000)")]
        public string? BarCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Shared { get; set; }
       // public List<Employee> Employees { get; set; }   =   new List<Employee>();
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DeviceType
    {
        Unknown,
        Laptop,
        Mobile,
        DeskPhone,
        HeadPhones,
        Other
    }
}
