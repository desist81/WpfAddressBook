using AppServiceInterfaces;
using ClientInfrastructure;
using ClientInfrastructure.ViewModelsBase;
using ClientModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule.ViewModels
{
    public class ContactsViewModel : BaseNotificationViewModel
    {
        IContactStateAppService _moduleState;
        IContactRepositoryAppService _repository;

        public ContactsViewModel(IContactModule module,
            IContactViewSharedContext context,
            IContactStateAppService moduleState)
           : base(module)
        {
            _moduleState = moduleState;
            this.RegionContext = context;
            this.AddCommand = new DelegateCommand(OnAddExecute);
        }

        #region Commands
        public DelegateCommand AddCommand { get; private set; }

        #endregion Commands

        #region Properties
        public IContactStateAppService ModuleState
        {
            get
            {
                return _moduleState;

            }
        }

        public bool InInEditMode
        {
            get
            {
                return _moduleState.IsEditMode;

            }
            set
            {
                _moduleState.IsEditMode = value;
                RaisePropertyChanged();


            }
        }

        #endregion Properties


        #region Add
        private void OnAddExecute()
        {
            InInEditMode = true;   
        }
        #endregion Add



    }
}
