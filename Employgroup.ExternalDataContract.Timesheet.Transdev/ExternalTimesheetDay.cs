using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Employgroup.ExternalDataContract.Timesheet.Transdev
{
    [DataContract]
    public class ExternalTimesheetDay
    {
        /// <summary>
        /// Gets or sets the employer token.
        /// </summary>
        /// <value>
        /// The employer token.
        /// </value>
        [DataMember]
        public string EmployerToken { get; set; }

        /// <summary>
        /// Gets or sets the abn.
        /// </summary>
        /// <value>
        /// The abn.
        /// </value>
        [DataMember]
        public string Abn { get; set; }

        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>
        /// The employee code.
        /// </value>
        [DataMember]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Gets or sets the employee token.
        /// </summary>
        /// <value>
        /// The employee token.
        /// </value>
        [DataMember]
        public string EmployeeToken { get; set; }

        /// <summary>
        /// Gets or sets the name of the position.
        /// </summary>
        /// <value>
        /// The name of the position.
        /// </value>
        [DataMember]
        public string PositionName { get; set; }

        /// <summary>
        /// Gets or sets the timesheet date.
        /// </summary>
        /// <value>
        /// The timesheet date.
        /// </value>
        [DataMember]
        public DateTime TimesheetDate { get; set; }

        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        /// <value>
        /// The sub entries.
        /// </value>
        [DataMember]
        public List<ExternalTimesheetEntry> TimesheetEntries { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [DataMember]
        public List<string> Comments { get; set; }  
    }
}
