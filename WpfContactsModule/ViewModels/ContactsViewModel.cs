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
            IContactStateAppService moduleState,
            IContactRepositoryAppService repository)
           : base(module)
        {
            _moduleState = moduleState;
            _repository = repository;
            this.RegionContext = context;
            this.AddCommand = new DelegateCommand(OnAddExecute);
            this.CloseCommand = new DelegateCommand(OnCloseExecute);
            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        #region Commands
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand CloseCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        #endregion Commands

        #region Properties
        public IContactStateAppService ModuleState
        {
            get
            {
                return _moduleState;

            }
        }

        public IContactViewSharedContext CurrentContext
        {
            get
            {
                return this.RegionContext as IContactViewSharedContext;

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
            DomainModel.Contact newContact = new DomainModel.Contact() { Id = Guid.NewGuid() };
            ContactBindingEntity newContactBindingEntity = new ContactBindingEntity(newContact)
            {
                DataState = DataState.Added
            };
            CurrentContext.EditItem = newContactBindingEntity;
            SaveCommand.RaiseCanExecuteChanged();
        }
        #endregion Add

        #region Close
        private void OnCloseExecute()
        {
            InInEditMode = false;
            CurrentContext.EditItem = null;
        }
        #endregion Close

        #region Save
        private void OnSaveExecute()
        {
            _repository?.SaveContact(CurrentContext.EditItem as ContactBindingEntity);
            InInEditMode = false;
            CurrentContext.CurrentItem = CurrentContext.EditItem;
            ModuleCommands.RefreshCommand.Execute(this);
        }

        private bool OnSaveCanExecute()
        {
            return CurrentContext.EditItem != null
                && (CurrentContext.EditItem as ContactBindingEntity).DataState != DataState.Undefined;
        }
        #endregion Save

    }
}
