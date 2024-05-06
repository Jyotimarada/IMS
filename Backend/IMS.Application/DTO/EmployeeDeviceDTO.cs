using Swashbuckle.AspNetCore.Annotations;

namespace IMS.Application.DTO
{

    /// <summary>
    /// EmployeeDeviceDTO class.
    /// </summary>
    public class EmployeeDeviceDTO
    {
        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        [SwaggerSchema(ReadOnly = true)]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the EmployeeName.
        /// </summary>
        [SwaggerSchema(ReadOnly = true)]
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the Devicename.
        /// </summary>
        [SwaggerSchema(ReadOnly = true)]
        public string? Devicename { get; set; }

        /// <summary>
        /// Gets or sets the DeviceId.
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the AssignedDate of the device.
        /// </summary>
        public DateTimeOffset AssignedDate { get; set; }

        /// <summary>
        /// Gets or sets the ReturnDate of the device.
        /// </summary>
        public DateTimeOffset ReturnDate { get; set; }

    }
}
