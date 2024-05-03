using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Domain.Entities
{
    public class Employee : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName ="varchar(200)")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "varchar(200)")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "varchar(500)")]
        public string? Title { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [Column(TypeName = "varchar(300)")]
        public string Email { get; set; } = string.Empty;

        public List<EmployeeDevice>? EmployeeDevices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Device>? Devices { get; set; }
    }
}
