using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Exercise1.GUI
{
    /// <summary>
    /// This class defines an a view model for the RunControl. The view model provides properties
    /// and logic for one Run object.
    /// </summary>
    public class RunViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RunViewModel(Run run) : base()
        {
            Run = run;
            GUID = run.GUID;
            AllInflows = new ObservableCollection<Inflow>(run.Inflows);
            SelectedInflow = AllInflows.FirstOrDefault();
        }
        /// <summary>
        /// The Run object that is presented by this view model
        /// </summary>
        public Run Run { get; set; }
        /// <summary>
        /// The GUID of the Run
        /// </summary>
        public Guid GUID { get; set; }
        /// <summary>
        /// The name of the Run
        /// </summary>
        public String Name
        {
            get { return Run.Name; }
            set
            {
                if (value == Run.Name) return;
                Run.Name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        /// <summary>
        /// The stored description of the run
        /// </summary>
        public String Description
        {
            get { return Run.Description; }
            set
            {
                if (value == Run.Description) return;
                Run.Description = value;
                NotifyPropertyChanged(nameof(Description));
            }

        }
        /// <summary>
        /// Indicates whether the run is considered current
        /// </summary>
        public Boolean IsCurrent
        {
            get { return Run.IsCurrent; }
            set
            {
                if (value == Run.IsCurrent) return;
                Run.IsCurrent = value;
                NotifyPropertyChanged(nameof(IsCurrent));
            }
        }
        /// <summary>
        /// All of the Inflow objects that are associated with this run
        /// </summary>
        public ObservableCollection<Inflow> AllInflows { get; set; }
        /// <summary>
        /// The Inflow object that is selected
        /// </summary>
        public Inflow SelectedInflow
        {
            get { return _selectedInflow; }
            set
            {
                if (_selectedInflow == value) return;
                _selectedInflow = value;
                NotifyPropertyChanged(nameof(SelectedInflow));
                if (_selectedInflow != null)
                    InflowViewModel = new InflowViewModel(_selectedInflow);
                else
                    InflowViewModel = null;
            }
        }
        protected Inflow _selectedInflow;
        /// <summary>
        /// The view model of the currently selected inflow
        /// </summary>
        public InflowViewModel InflowViewModel
        {
            get { return _inflowViewModel; }
            set
            {
                if (_inflowViewModel == value) return;
                if (_inflowViewModel != null)
                    _inflowViewModel.Dispose();
                _inflowViewModel = value;
                NotifyPropertyChanged(nameof(InflowViewModel));
            }
        }
        protected InflowViewModel _inflowViewModel;
    }
}
