using AppServiceInterfaces;
using ClientInfrastructure;
using ClientInfrastructure.ViewModelsBase;
using ClientModel;
using Prism.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule.ViewModels
{
    public class ContactDetailsViewModel : BaseNotificationViewModel
    {
        private IContactRepositoryAppService _repository;
        private ObservableCollection<ContactFieldBindingEntity> _emailsCollection;
        private ObservableCollection<ContactFieldBindingEntity> _phonesCollection;
        public DelegateCommand<ContactFieldBindingEntity> DeleteContactFieldCommand { get; private set; }
        public DelegateCommand<ContactFieldBindingEntity> AddContactFieldCommand { get; private set; }
        public ContactDetailsViewModel(IContactModule module,
                     IContactViewSharedContext context,
                     IContactRepositoryAppService repository)
                    : base(module)
        {
            _repository = repository;
            this.RegionContext = context;
            this.RegionContext.PropertyChanged += RegionContext_PropertyChanged;
            this.DeleteContactFieldCommand = new DelegateCommand<ContactFieldBindingEntity>(OnDeleteContactFieldExecute);
            this.AddContactFieldCommand = new DelegateCommand<ContactFieldBindingEntity>(OnAddContactFieldExecute);

        }

        private void RegionContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "EditItem")
            {
                _emailsCollection = null;
                _phonesCollection = null;
                RaisePropertyChanged(nameof(ContactPhonesCollection));
                RaisePropertyChanged(nameof(ContactEmailsCollection));
            }
        }

        public ContactBindingEntity EditContact
        {
            get
            {
                IContactViewSharedContext context = this.RegionContext as IContactViewSharedContext;
                return context.EditItem as ContactBindingEntity;

            }
        }

        public ObservableCollection<ContactFieldBindingEntity> ContactEmailsCollection
        {
            get
            {
                if (_emailsCollection == null)
                {
                    if (this.EditContact == null)
                    {
                        _emailsCollection = new ObservableCollection<ContactFieldBindingEntity>();

                    }
                    else
                    {
                        var emails = this.EditContact.Fields.Where(f =>
                                     f.FieldType == DomainModel.FieldType.Email
                                     && f.DataState != DataState.Deleted);
                        _emailsCollection = new ObservableCollection<ContactFieldBindingEntity>(emails);
                    }
                }
                return _emailsCollection;

            }
        }

        public ObservableCollection<ContactFieldBindingEntity> ContactPhonesCollection
        {
            get
            {
                if (_phonesCollection == null)
                {
                    if (this.EditContact == null)
                    {
                        _emailsCollection = new ObservableCollection<ContactFieldBindingEntity>();

                    }
                    else
                    {
                        var phones = this.EditContact.Fields.Where(f =>
                                 f.FieldType == DomainModel.FieldType.Phone
                                 && f.DataState != DataState.Deleted);
                        _phonesCollection = new ObservableCollection<ContactFieldBindingEntity>(phones);
                    }
                }
                return _phonesCollection;
            }
        }

        private void OnDeleteContactFieldExecute(ContactFieldBindingEntity args)
        {
            var field = this.EditContact.Fields.FirstOrDefault(f => f.Id == args.Id);
            field.DataState = ClientInfrastructure.DataState.Deleted;
            if (args.FieldType == DomainModel.FieldType.Email)
            {
                ContactEmailsCollection.Remove(args);
            }
            else if (args.FieldType == DomainModel.FieldType.Phone)
            {
                ContactPhonesCollection.Remove(args);
            }
            this.EditContact.NotifyContactFieldsChanged();
        }


        private void OnAddContactFieldExecute(ContactFieldBindingEntity args)
        {
            args.DataState = DataState.Added;
            //args.Contact = this.EditContact;
            this.EditContact.Fields.Add(args);
            if (args.FieldType == DomainModel.FieldType.Email)
            {
                ContactEmailsCollection.Add(args);
            }
            else if (args.FieldType == DomainModel.FieldType.Phone)
            {
                ContactPhonesCollection.Add(args);
            }
            this.EditContact.NotifyContactFieldsChanged();
        }

    }
}
