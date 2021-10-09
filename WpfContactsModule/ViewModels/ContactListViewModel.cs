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
    public class ContactListViewModel : BaseNotificationViewModel
    {
        IContactStateAppService _moduleState;
        IContactRepositoryAppService _repository;

        public ContactListViewModel(IContactModule module,
            IContactViewSharedContext context,
            IContactStateAppService moduleState,
            IContactRepositoryAppService repository)
           : base(module)
        {
            _moduleState = moduleState;
            _repository = repository;
            this.RegionContext = context;
            context.CurrentIndex = 0;
            this.DeleteCommand = new DelegateCommand(OnDeleteExecute, OnDeleteCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExecute);
            ModuleCommands.RefreshCommand.RegisterCommand(RefreshCommand);
        }

        #region Commands
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand RefreshCommand { get; private set; }

        #endregion Commands

        #region Properties
        public ObservableCollection<ContactBindingEntity> ContactsCollection
        {
            get
            {
                return _repository?.GetContactsCollection();

            }
        }

        #endregion Properties

        #region Delete
        private void OnDeleteExecute()
        {
            _repository?.DeleteContact(RegionContext.CurrentItem as ContactBindingEntity);
            RaisePropertyChanged(StaticReflection.GetMemberName<ContactListViewModel>(p => p.ContactsCollection));

        }

        private bool OnDeleteCanExecute()
        {
            return this.RegionContext.CurrentItem != null;
        }
        #endregion Delete


        #region Refresh
        private void OnRefreshExecute()
        {
            RaisePropertyChanged(StaticReflection.GetMemberName<ContactListViewModel>(p => p.ContactsCollection));
        }

        #endregion Refresh
    }
}
