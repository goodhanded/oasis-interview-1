using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Exercise1.GUI
{
    /// <summary>
    /// This class defines a "run" of a water resources simulation model, where "run" is a term
    /// for a simulated scenario of the water resources system. A run is defined by a collection
    /// of inputs. To keep the exercise relatively simple, the only type of input represented
    /// here is an "inflow". So for the purposes of this exercise, a run can be understood
    /// as mainly a collection of inflows.
    /// </summary>
    public class Run
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Run(Guid guid, String name, String description, Boolean isCurrent)
        {
            GUID = guid;
            Name = name;
            Description = description;
            IsCurrent = isCurrent;
        }
        /// <summary>
        /// The GUID that uniquely identifies the Run obect in the data context
        /// </summary>
        public Guid GUID { get; set; }
        /// <summary>
        /// The name of the Run
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// The stored description of the run
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Indicates whether the run is considered current
        /// </summary>
        public Boolean IsCurrent { get; set; }

        /// <summary>
        /// The collection of all inflows that are associated with this run
        /// </summary>
        /// <remarks>It is impractical to include Entity Framework in this exercise project,
        /// so this property was created to stand in for a "navigation property" created with
        /// Entity Framework.</remarks>
        public IEnumerable<Inflow> Inflows
        {
            get
            {
                var inflowGUIDs = DataContext.RunInflowAssociations.Where(o => o.RunGUID == GUID)
                        .Select(o => o.InflowGUID).ToList();
                return DataContext.Inflows.Where(i => inflowGUIDs.Contains(i.GUID));
            }
        }
    }
}
