using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Exercise1.GUI
{
    /// <summary>
    /// This class defines an inflow location in a water resources system.
    /// </summary>
    public class Inflow
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Inflow(Guid guid, int number, String description, Double minFlow, Double maxFlow)
        {
            GUID = guid;
            Number = number;
            Description = description;
            MinFlow = minFlow;
            MaxFlow = maxFlow;
        }
        /// <summary>
        /// The GUID that uniquely identifies this Inflow
        /// </summary>
        public Guid GUID { get; set; }
        /// <summary>
        /// The number of the inflow
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// The stored description of the inflow
        /// </summary>
        public String Description{ get; set; }
        /// <summary>
        /// The minimum that is possible for this inflow
        /// </summary>
        public Double MinFlow { get; set; }
        /// <summary>
        /// The maximum that is possible for this inflow
        /// </summary>
        public Double MaxFlow { get; set; }

        /// <summary>
        /// Gage Readings associated with this inflow
        /// </summary>
        public IEnumerable<GageReading> GageReadings => DataContext.GageReadings.Where(r => r.InflowGUID == GUID);

        /// <summary>
        /// The collection of all runs in the data context that this inflow is associated with.
        /// </summary>
        /// <remarks>It is impractical to include Entity Framework in this exercise project,
        /// so this property was created to stand in for a "navigation property" created with
        /// Entity Framework.</remarks>
        public IEnumerable<Run> Runs
        {
            get
            {
                var runGUIDs = DataContext.RunInflowAssociations.Where(o => o.InflowGUID == GUID)
                        .Select(o => o.RunGUID).ToList();
                return DataContext.Runs.Where(r => runGUIDs.Contains(r.GUID));
            }
        }

    }
}
