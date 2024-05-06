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
    /// <summary>
     /// Device class.
     /// </summary>
    public class Device : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [Column(TypeName = "varchar(400)")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        [Column(TypeName = "Text")]
        public string? Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public DeviceType Type { get; set; } = DeviceType.Unknown;

        /// <summary>
        /// Gets or sets the BarCode.
        /// </summary>
        [Column(TypeName = "Varchar(8000)")]
        public string? BarCode { get; set; }

        /// <summary>
        /// Gets or sets the Shared.
        /// </summary>
        public bool Shared { get; set; }
    }

    /// <summary>
    /// DeviceType enum.
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// type unknown
        /// </summary>
        Unknown,
        /// <summary>
        /// Device type is Laptop.
        /// </summary>
        Laptop,
        /// <summary>
        /// Device type is Mobile.
        /// </summary>
        Mobile,
        /// <summary>
        /// Device type is DeskPhone.
        /// </summary>
        DeskPhone,
        /// <summary>
        /// Device type is HeadPhones.
        /// </summary>
        HeadPhones,
        /// <summary>
        /// Device type is other which is not supported.
        /// </summary>
        Other
    }
}
