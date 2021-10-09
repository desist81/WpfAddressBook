using ClientInfrastructure;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule
{
    internal class ContactViewSharedContext : ViewSharedContext, IContactViewSharedContext
    {
        INotifyPropertyChanged _editItem;
        int _currentIndex;

        public ContactViewSharedContext(string moduleName) : base(moduleName)
        {

        }
        public int CurrentIndex
        {
            get
            {
                return _currentIndex;
            }
            set
            {

                if (_currentIndex != value)
                {
                    _currentIndex = value;
                    RaisePropertyChanged();
                }

            }
        }
        public INotifyPropertyChanged EditItem
        {
            get
            {
                return _editItem;
            }
            set
            {

                if (_editItem != value)
                {
                    _editItem = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}