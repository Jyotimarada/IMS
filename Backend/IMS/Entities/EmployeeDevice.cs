using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Entities
{
    public class EmployeeDevice : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset AssignedDate { get; set; }  

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? ReturnDate { get; set; }    

        /// <summary>
        /// 
        /// </summary>
        public Employee Employee { get; set; } = new Employee();

        /// <summary>
        /// 
        /// </summary>
        public Device Device { get; set; } =  new Device();
    }
}
