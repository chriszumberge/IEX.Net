using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IEX.Net
{
    /// <summary>
    /// Oberservable object with INotifyPropertyChanged implemented.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingStore">The backing store.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="onChanged">The on changed.</param>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        protected virtual bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            // If value wasn't changed, do nothing and return false
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            // Set the value
            backingStore = value;
            // Call the optional on changed parameter
            onChanged?.Invoke();
            // Raise the property changed event
            OnPropertyChanged(propertyName);
            // Return true, to indicate value was changed
            return true;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
