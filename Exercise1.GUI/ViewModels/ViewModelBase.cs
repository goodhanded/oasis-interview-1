using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace Exercise1.GUI
{
    /// <summary>
    /// This abstract class defines a base class for all view models in the project.
    /// </summary>
    public abstract class ViewModelBase : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// This method Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose() 
        {
        }
        /// <summary>
        /// This event represents the method that will handle the PropertyChanged event raised when
        /// a property is changed on a component.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This method raises the property changed event for the property given in the 
        /// PropertyChangedEventArgs parameter.
        /// </summary>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// This method raises the property changed event for the property named in the parameter.
        /// The parameter for this method is a simple string, so that the caller does
        /// not have to instantiate a PropertyChangedEventArgs object.
        /// </summary>
        protected void NotifyPropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
