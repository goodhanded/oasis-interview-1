using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Exercise1.GUI
{
    /// <summary>
    /// This class defines a view model for the MainWindow of the application.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel() : base()
        {
            SelectedRun = AllRuns.FirstOrDefault();
        }
        /// <summary>
        /// The collection of all runs from which a selection may be made
        /// </summary>
        public ObservableCollection<Run> AllRuns { get { return DataContext.Runs; } }
        /// <summary>
        /// The Run object that is selected
        /// </summary>
        public Run SelectedRun
        {
            get { return _selectedRun; }
            set
            {
                if (_selectedRun == value) return;
                _selectedRun = value;
                NotifyPropertyChanged(nameof(SelectedRun));
                RunViewModel = new RunViewModel(_selectedRun);
            }
        }
        protected Run _selectedRun;
        /// <summary>
        /// The view model of the currently selected run
        /// </summary>
        public RunViewModel RunViewModel
        {
            get { return _runViewModel; }
            set
            {
                if (_runViewModel == value) return;
                if (_runViewModel != null)
                    _runViewModel.Dispose();
                _runViewModel = value;
                NotifyPropertyChanged(nameof(RunViewModel));
            }
        }
        protected RunViewModel _runViewModel;

    }
}
