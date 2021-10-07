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

        }

        #region Commands
        public DelegateCommand DeleteCommand { get; private set; }

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

        #region Methods
        private void OnDeleteExecute()
        {
            ContactsCollection.Remove(RegionContext.CurrentItem as ContactBindingEntity);
        }

        private bool OnDeleteCanExecute()
        {
            return this.RegionContext.CurrentItem != null;
        }
        #endregion Methods
    }
}
