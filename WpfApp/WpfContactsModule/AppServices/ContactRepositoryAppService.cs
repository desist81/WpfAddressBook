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
        public ContactRepositoryAppService(IContactDataProvider contactDataProvider)
        {           
            _contactDataProvider = contactDataProvider;
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
