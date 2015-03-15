using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Employgroup.ExternalDataContract.Timesheet.Transdev.Enumerators;

namespace Employgroup.ExternalDataContract.Timesheet.Transdev
{
    [DataContract]
    public class ExternalTimesheetEntry
    {
        /// <summary>
        /// Gets or sets the hours.
        /// </summary>
        /// <value>
        /// The hours.
        /// </value>
        [DataMember]
        public Decimal? Hours { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        [DataMember]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        [DataMember]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the is done.
        /// </summary>
        /// <value>
        /// The is done.
        /// </value>
        [DataMember]
        public bool? IsDone { get; set; }

        /// <summary>
        /// Gets or sets the type of the entry.
        /// </summary>
        /// <value>
        /// The type of the entry.
        /// </value>
        [DataMember]
        public ExternalEntryType EntryType { get; set; }

        /// <summary>
        /// Gets or sets the custom code.
        /// </summary>
        /// <value>
        /// The custom code.
        /// </value>
        [DataMember]
        public string CustomCode { get; set; }

        /// <summary>
        /// Gets or sets the sub entries.
        /// </summary>
        /// <value>
        /// The sub entries.
        /// </value>
        [DataMember]
        public List<ExternalTimesheetEntry> SubTimesheetEntries { get; set; }

    }
}
