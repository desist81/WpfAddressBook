using AppServiceInterfaces;
using ClientInfrastructure;
using ClientModel;
using DataProviderInterfates;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule.AppServices
{
    public class ContactRepositoryAppService : IContactRepositoryAppService
    {

        private IContactDataProvider _contactDataProvider;
        private IContactFieldDataProvider _contactFieldDataProvider;
        public ContactRepositoryAppService(IContactDataProvider contactDataProvider,
            IContactFieldDataProvider contactFieldDataProvider)
        {           
            _contactDataProvider = contactDataProvider;
            _contactFieldDataProvider = contactFieldDataProvider;
        }
        public ObservableCollection<ContactBindingEntity> GetContactsCollection(string searchText)
        {
            var contacts = _contactDataProvider.GetContacts(searchText);
           
            var bindingContacts = contacts.Select(c => new ContactBindingEntity(c)).ToList();
            var observableContacts = new ObservableCollection<ContactBindingEntity>(bindingContacts);
            return observableContacts;
        }

        public void DeleteContact(ContactBindingEntity contact)
        {
            if (contact != null)
            {
                _contactDataProvider.DeleteContat(contact.Id);
            }

        }

        public void SaveContact(ContactBindingEntity contact)
        {
            
            var addedFields = contact.Fields.Where(f => f.DataState == DataState.Added).ToList();
            foreach (var addedField in addedFields)
            {
                // _contactFieldDataProvider.AddContactField(addedField.DomainEntity);
                contact.Fields.Add(addedField);
            }
            var deletedFields = contact.Fields.Where(f => f.DataState == DataState.Deleted).ToList();
            foreach (var deletedField in deletedFields)
            {
                // _contactFieldDataProvider.DeleteContactField(deletedField.Id);
                contact.Fields.Remove(deletedField);
            }

            if (contact.DataState == DataState.Added)
            {
                _contactDataProvider.AddContat(contact.DomainEntity);
            }
            else if (contact.DataState == DataState.Modified)
            {
                _contactDataProvider.UpdateContat(contact.DomainEntity);
            }
        }
    }
}
