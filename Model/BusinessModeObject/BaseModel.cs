using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;

namespace Model.BusinessModeObject
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        // Dispatcher associated with model
        protected Dispatcher _dispatcher;
        private PropertyChangedEventHandler _propertyChangedEvent;

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseModel()
        {
            // Save off dispatcher 
            //_dispatcher = Dispatcher.CurrentDispatcher;
           
           
            
        }

        /// <summary>
        /// PropertyChanged event for INotifyPropertyChanged implementation.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                ConfirmOnUIThread();
                _propertyChangedEvent += value;
            }
            remove
            {
                ConfirmOnUIThread();
                _propertyChangedEvent -= value;
            }
        }

        /// <summary>
        /// Utility function for use by subclasses to notify that a property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        protected void Notify(string propertyName)
        {
            ConfirmOnUIThread();
            ConfirmPropertyName(propertyName);

            if (_propertyChangedEvent != null)
            {
                _propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Debugging facility that ensures methods are called on the UI thread.
        /// </summary>
        [Conditional("Debug")]
        protected void ConfirmOnUIThread()
        {
            Debug.Assert(Dispatcher.CurrentDispatcher == _dispatcher, "Call must be made on UI thread.");
        }

        /// <summary>
        /// Debugging facility that ensures the property does exist on the class.
        /// </summary>
        /// <param name="propertyName"></param>
        [Conditional("Debug")]
        private void ConfirmPropertyName(string propertyName)
        {
            Debug.Assert(GetType().GetProperty(propertyName) != null, "Property " + propertyName + " is not a valid name.");
        }
    }
}
