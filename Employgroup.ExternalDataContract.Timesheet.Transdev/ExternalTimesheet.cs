using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Employgroup.ExternalDataContract.Timesheet.Transdev
{
    [DataContract]
    public class ExternalTimesheet
    {
        /// <summary>
        /// Gets or sets the timesheet days.
        /// </summary>
        /// <value>
        /// The timesheet days.
        /// </value>
        [DataMember]
        public List<ExternalTimesheetDay> TimesheetDays { get; set; } 
    }
}
