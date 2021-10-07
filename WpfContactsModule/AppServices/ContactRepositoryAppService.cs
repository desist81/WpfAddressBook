using AppServiceInterfaces;
using ClientModel;
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
        public ObservableCollection<ContactBindingEntity> GetContactsCollection()
        {
            //TODO: Reading from data provider
            IEnumerable<ContactBindingEntity> contacts =
                new List<Contact>() {
                    new Contact{FullName = "Contact 1"},
                    new Contact{FullName = "Contact 2"},
                    new Contact{FullName = "Contact 3"}}
                .Select(c => new ContactBindingEntity(c));

            var observableContacts = new ObservableCollection<ContactBindingEntity>(contacts);
            return observableContacts;
        }
    }
}
