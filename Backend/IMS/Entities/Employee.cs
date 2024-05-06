using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Domain.Entities
{
    /// <summary>
    /// Employee class.
    /// </summary>
    public class Employee : BaseEntity
    {

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        [Column(TypeName ="varchar(200)")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        [Column(TypeName = "varchar(200)")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        [Column(TypeName = "varchar(500)")]
        public string? Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        [Column(TypeName = "varchar(300)")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the EmployeeDevices.
        /// </summary>
        public List<EmployeeDevice>? EmployeeDevices { get; set; }

        /// <summary>
        /// Gets or sets the Devices.
        /// </summary>
        public List<Device>? Devices { get; set; }
    }
}
