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

        #region Constructor

        public NotifyProperyChangedBase()
        {

        }

        #endregion

     
        #region Property changed

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
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
            Validate();
            RaisePropertyChanged(propertyName);
            OnPropertyChangedNotification(isPropertyValueChanged);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Validation

        private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public bool HasErrors => errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (errors.ContainsKey(propertyName)) return errors[propertyName];
            return new string[0];
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!errors.ContainsKey(propertyName))
            {
                errors.Add(propertyName, new List<string>());
            }

            errors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {
            if (errors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public virtual bool Validate()
        {
            return true;
        }

        #endregion  Validation
    }

}

