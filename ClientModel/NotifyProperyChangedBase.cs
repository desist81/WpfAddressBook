using ClientInfrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public abstract partial class NotifyProperyChangedBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private Dictionary<string, List<string>> errorMessages = new Dictionary<string, List<string>>();

        #endregion

        #region Constructor

        public NotifyProperyChangedBase()
        {

        }

        #endregion

        public DataState DataState { get; set; }
        #region Property changed
        internal virtual void OnPropertyChangedNotification(bool isPropertyValueChanged)
        { }
        protected bool CheckPropertyChanged<T>(T oldValue, T newValue)
        {
            if (oldValue == null && newValue == null)
            {
                return false;
            }

            if ((oldValue == null && newValue != null) || !oldValue.Equals((T)newValue))
            {
                return true;
            }

            return false;
        }

        protected virtual void FirePropertyChanged(string propertyName, bool isPropertyValueChanged = true)
        {
            if (this.DataState == DataState.Undefined) this.DataState = DataState.Modified;
            RaisePropertyChanged(propertyName);
            OnPropertyChangedNotification(isPropertyValueChanged);
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Errors region
        public bool HasErrors => errorMessages.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            return errorMessages.ContainsKey(propertyName) ?
                errorMessages[propertyName] : null;
        }
        private void NotifyErrorsChanged(string propertyName)
        {
            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
        protected void ClearAllErrorMessages()
        {
            errorMessages = new Dictionary<string, List<string>>();
        }

        private void ClearErrorMessagesForProperty(string propertyName)
        {
            errorMessages.Remove(propertyName);
        }

        #endregion

    }


}
