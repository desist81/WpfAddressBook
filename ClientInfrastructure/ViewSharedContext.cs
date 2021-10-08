using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfrastructure
{
    public class ViewSharedContext : BindableBase, IViewSharedContext
    {
        public event EventHandler IsModuleActiveChanged;

        private string _moduleName;
        private INotifyPropertyChanged _currentItem;
        bool _isModuleActive = false;
      

        public ViewSharedContext(string moduleName)
        {
            _moduleName = moduleName;
        }

        public string ModuleName
        {
            get
            {
                return _moduleName;
            }
        }

        public bool IsModuleActive
        {
            get
            {
                return _isModuleActive;
            }
            set
            {
                if (_isModuleActive != value)
                {
                    _isModuleActive = value;
                    if (IsModuleActiveChanged != null)
                    {
                        IsModuleActiveChanged(this, null);
                    }
                }
            }
        }
           
        public INotifyPropertyChanged CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {

                if (_currentItem != value)
                {
                    _currentItem = value;
                    if (_currentItem != null)
                    {
                        RaisePropertyChanged();
                    }

                }               

            }
        }

        

    }

}
