using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Employgroup.ExternalDataContract.TimesheetRoster.Transdev
{
    [DataContract]
    public class ExternalRosteredDay
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
        /// Gets or sets the rostered date.
        /// </summary>
        /// <value>
        /// The roster date.
        /// </value>
        [DataMember]
        public DateTime RosteredDate { get; set; }

        /// <summary>
        /// Gets or sets the rostered tasks.
        /// </summary>
        /// <value>
        /// The roster tasks.
        /// </value>
        [DataMember]
        public List<ExternalRosteredTask> RosteredTasks { get; set; }
    }
}
