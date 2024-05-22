using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Exercise1.GUI
{
    /// <summary>
    /// This class defines an association between one inflow and one run, where there is a many-to-many
    /// relationship between inflows and runs.
    /// </summary>
    public class RunInflowAssociation
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RunInflowAssociation(Guid runGuid, Guid inflowGuid)
        {
            RunGUID = runGuid;
            InflowGUID = inflowGuid;
        }
        /// <summary>
        /// The GUID that uniquely identifies the Run of this association
        /// </summary>
        public Guid RunGUID { get; set; }
        /// <summary>
        /// The GUID that uniquely identifies the Inflow of this association
        /// </summary>
        public Guid InflowGUID { get; set; }
    }
}
