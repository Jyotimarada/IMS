using IMS.Domain.Entities;
using System.ComponentModel;

namespace IMS.Application.DTO
{
    /// <summary>
    /// The DeviceDTO class
    /// </summary>
    public class DeviceDTO 
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [ReadOnly(true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the device description.
        /// </summary>
        /// <value>
        /// The description of the device.
        /// </value>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the device barcode.
        /// </summary>
        /// <value>
        /// The barcode of the device.
        /// </value>
        public string? Barcode { get; set; }

        /// <summary>
        /// Gets or sets the if the device is shared.
        /// </summary>
        /// <value>
        /// The shared status of the device.
        /// </value>
        public bool Shared {  get; set; }

        /// <summary>
        /// Gets or sets type of the device.
        /// </summary>
        /// <value>
        /// The device type.
        /// </value>
        public DeviceType Type { get; set; }

    }
}
