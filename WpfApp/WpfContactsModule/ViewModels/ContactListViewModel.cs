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
        private readonly IContactStateAppService _moduleState;
        private readonly IContactRepositoryAppService _repository;
        private string _searchText;

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
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ContactsCollection));
            }
        }
        public ObservableCollection<ContactBindingEntity> ContactsCollection
        {
            get
            {
                return _repository?.GetContactsCollection(SearchText);

            }
        }

        #endregion Properties

        #region Delete
        private void OnDeleteExecute()
        {
            _repository?.DeleteContact(RegionContext.CurrentItem as ContactBindingEntity);
            RaisePropertyChanged(nameof(ContactsCollection));

        }

        private bool OnDeleteCanExecute()
        {
            return this.RegionContext.CurrentItem != null;
        }
        #endregion Delete

        #region Refresh
        private void OnRefreshExecute()
        {
            SearchText = String.Empty;
        }

        #endregion Refresh

    }
}
