using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfrastructure.ViewModelsBase
{
    public abstract class BaseNotificationViewModel : BindableBase, IViewModel
    {
        IBaseModule _module;
        IViewSharedContext _regionContext;
        bool _isActive;


        public BaseNotificationViewModel(IBaseModule module)
            : base()
        {
            _module = module;
        }

        public IBaseModule Module
        {
            get
            {
                return _module;
            }
        }

        public IViewSharedContext RegionContext
        {
            get
            {
                return _regionContext;
            }
            set
            {
                _regionContext = value;
                RaisePropertyChanged(StaticReflection.GetMemberName(() => RegionContext));
            }
        }

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    if (IsActiveChanged != null)
                    {
                        IsActiveChanged(this, null);
                    }
                }
            }
        }

        public event EventHandler IsActiveChanged;

    }
}
