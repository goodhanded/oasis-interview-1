using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Exercise1.GUI
{
    /// <summary>
    /// This class defines an a view model for the InflowControl. The view model provides properties
    /// and logic for one Inflow object.
    /// </summary>
    public class InflowViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InflowViewModel(Inflow inflow) : base()
        {
            Inflow = inflow;
            GUID = inflow.GUID;
            Runs = new ObservableCollection<Run>(inflow.Runs);
        }
        /// <summary>
        /// The Inflow object that is presented by this view model
        /// </summary>
        public Inflow Inflow { get; set; }
        /// <summary>
        /// The GUID that uniquely identifies the Inflow obect in the data context
        /// </summary>
        public Guid GUID { get; set; }
        /// <summary>
        /// The number of the inflow object
        /// </summary>
        public int Number
        {
            get { return Inflow.Number; }
            set
            {
                if (value == Inflow.Number) return;
                Inflow.Number = value;
                NotifyPropertyChanged(nameof(Number));
            }
        }
        /// <summary>
        /// The stored description of the inflow object
        /// </summary>
        public String Description
        {
            get { return Inflow.Description; }
            set
            {
                if (value == Inflow.Description) return;
                Inflow.Description = value;
                NotifyPropertyChanged(nameof(Description));
            }

        }
        /// <summary>
        /// The minimum that is possible for this inflow
        /// </summary>
        public Double MinFlow
        {
            get { return Inflow.MinFlow; }
            set
            {
                if (value == Inflow.MinFlow) return;
                Inflow.MinFlow = value;
                NotifyPropertyChanged(nameof(MinFlow));
            }
        }
        /// <summary>
        /// The maximum that is possible for this inflow
        /// </summary>
        public Double MaxFlow
        {
            get { return Inflow.MaxFlow; }
            set
            {
                if (value == Inflow.MaxFlow) return;
                Inflow.MaxFlow = value;
                NotifyPropertyChanged(nameof(MaxFlow));
            }
        }
        /// <summary>
        /// The collection of Runs that this inflow is associated with
        /// </summary>
        public ObservableCollection<Run> Runs { get; set; }
    }
}
