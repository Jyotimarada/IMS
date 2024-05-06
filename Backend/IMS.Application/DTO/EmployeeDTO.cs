using Swashbuckle.AspNetCore.Annotations;

namespace IMS.Application.DTO
{
    /// <summary>
    /// EmployeeDTO class.
    /// </summary>
    public class EmployeeDTO 
    {
        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the FirstName of the employee.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the LastName of the employee.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Description of the employee.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the email of the employee.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the device count owned by the employee.
        /// </summary>
        public int Devices { get; set; } = 0;

    }
}
