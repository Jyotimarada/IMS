using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    /// <summary>
    /// EmployeeDevice class.
    /// </summary>
    public class EmployeeDevice : BaseEntity
    {
        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the DeviceId.
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the AssignedDate.
        /// </summary>
        public DateTimeOffset AssignedDate { get; set; }

        /// <summary>
        /// Gets or sets the ReturnDate.
        /// </summary>
        public DateTimeOffset? ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets the Employee.
        /// </summary>
        public Employee Employee { get; set; } = new Employee();

        /// <summary>
        /// Gets or sets the Device.
        /// </summary>
        public Device Device { get; set; } =  new Device();
    }
}
