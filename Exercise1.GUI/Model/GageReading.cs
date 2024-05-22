using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Exercise1.GUI
{
    /// <summary>
    /// This class defines recording of a gage measurement for an inflow. Every gage reading belongs
    /// to one Inflow object, as indicated by the 'InflowGUID' property.
    /// </summary>
    public class GageReading
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GageReading(Guid guid, Double flowValue, DateTime timeStamp, Guid inflowGuid)
        {
            GUID = guid;
            FlowValue = flowValue;
            TimeStamp = timeStamp;
            InflowGUID= inflowGuid;
        }
        /// <summary>
        /// The GUID that uniquely identifies the GageReading obect in the data context
        /// </summary>
        public Guid GUID { get; set; }
        /// <summary>
        /// The flow value that was recorded
        /// </summary>
        public Double FlowValue { get; set; }
        /// <summary>
        /// The date/time at which the reading ocurred
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// The GUID that identifies the inflow where this gage reading occurred
        /// </summary>
        public Guid InflowGUID { get; set; }
    }
}
