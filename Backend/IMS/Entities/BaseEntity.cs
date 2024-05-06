using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    /// <summary>
    /// BaseEntity class.
    /// </summary>
    public class BaseEntity
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the DateCreated.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the DateUpdated.
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the DateDeleted.
        /// </summary>
        public DateTimeOffset? DateDeleted { get; set; }
    }
}
