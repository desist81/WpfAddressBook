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
            this.EditCommand = new DelegateCommand(OnEditExecute);
            this.CloseCommand = new DelegateCommand(OnCloseExecute);
            this.SaveCommand = new DelegateCommand(OnSaveExecute);
            ModuleCommands.EditCommand.RegisterCommand(this.EditCommand);

        }


        #region Commands
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand EditCommand { get; private set; }
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
            AttachListeners();
            RaisePropertyChanged(nameof(CanSave));
        }


        #endregion Add


        #region Edit
        private void OnEditExecute()
        {
            InInEditMode = true;
            CurrentContext.EditItem = CurrentContext.CurrentItem as NotifyProperyChangedBase;
            DetachListeners();

        }

        #endregion Edit

        #region Close
        private void OnCloseExecute()
        {
            InInEditMode = false;
            CurrentContext.EditItem.PropertyChanged -= EditItem_PropertyChanged;
            CurrentContext.EditItem.ErrorsChanged -= EditItem_ErrorsChanged;
            CurrentContext.EditItem = null;
        }
        #endregion Close

        #region Save
        private void OnSaveExecute()
        {
            if (CurrentContext.EditItem.Validate())
            {
                _repository?.SaveContact(CurrentContext.EditItem as ContactBindingEntity);
                CurrentContext.CurrentItem = CurrentContext.EditItem;
                OnCloseExecute();
                ModuleCommands.RefreshCommand.Execute(this);
            }
        }

        public bool CanSave => CurrentContext.EditItem != null && !CurrentContext.EditItem.HasErrors
                && (CurrentContext.EditItem as ContactBindingEntity).DataState != DataState.Undefined;

        #endregion Save

        #region Private Methods
        private void EditItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void EditItem_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(CanSave));
        }

        private void AttachListeners()
        {
            CurrentContext.EditItem.PropertyChanged += EditItem_PropertyChanged;
            CurrentContext.EditItem.ErrorsChanged += EditItem_ErrorsChanged;
        }
        private void DetachListeners()
        {
            CurrentContext.EditItem.PropertyChanged += EditItem_PropertyChanged;
            CurrentContext.EditItem.ErrorsChanged += EditItem_ErrorsChanged;
        }
        #endregion Private Methods
    }
}
