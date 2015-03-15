using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Employgroup.ExternalDataContract.TimesheetRoster.Transdev
{
    [DataContract]
    public class ExternalRoster
    {
        [DataMember]
        public List<ExternalRosteredDay> RosteredDays { get; set; }

        [DataMember]
        public List<ExternalRosteredDayOff> RosteredDaysOff { get; set; } 
    }
}
