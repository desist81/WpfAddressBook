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
            this.DeleteCommand = new DelegateCommand(OnDeleteExecute, OnDeleteCanExecute);
            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExecute);
            ModuleCommands.SaveCommand.RegisterCommand(SaveCommand);
            ModuleCommands.RefreshCommand.RegisterCommand(RefreshCommand);
        }

        #region Commands
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
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

        #region Save
        private void OnSaveExecute()
        {
            _repository?.SaveContact(RegionContext.CurrentItem as ContactBindingEntity);
            RaisePropertyChanged(StaticReflection.GetMemberName<ContactListViewModel>(p => p.ContactsCollection));
        }

        private bool OnSaveCanExecute()
        {
            return this.RegionContext.CurrentItem != null;
        }
        #endregion Save

        #region Refresh
        private void OnRefreshExecute()
        {
            RaisePropertyChanged(StaticReflection.GetMemberName<ContactListViewModel>(p => p.ContactsCollection));
        }

        #endregion Refresh
    }
}
