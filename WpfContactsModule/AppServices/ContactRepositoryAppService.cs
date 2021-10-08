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
        static List<ContactBindingEntity> contacts;
        public ObservableCollection<ContactBindingEntity> GetContactsCollection()
        {
            //TODO: Reading from data provider
            if (contacts == null)
            {
                contacts =
                  new List<Contact>() {
                    new Contact{FullName = "Contact 1"},
                    new Contact{FullName = "Contact 2"},
                    new Contact{FullName = "Contact 3"}}
                  .Select(c => new ContactBindingEntity(c))
                  .ToList();
            }

            var observableContacts = new ObservableCollection<ContactBindingEntity>(contacts);
            return observableContacts;
        }

        public void DeleteContact(ContactBindingEntity contact)
        {
            //TODO: Reading from data provider
            if (contacts != null)
            {
               contacts.Remove(contact);
            }

        }

        public void AddContact(ContactBindingEntity contact)
        {
            //TODO: Add data to data provider
            if (contacts != null)
            {
                contacts.Add(contact);
            }
        }

        public void SaveContact(ContactBindingEntity contact)
        {
            //TODO: Save using data provider
           
        }
    }
}
