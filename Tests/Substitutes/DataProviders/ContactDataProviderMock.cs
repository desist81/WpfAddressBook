using DataProviderInterfates;
using DomainModel;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitutes.DataProviders
{
    public class ContactDataProviderMock : DataProvider, IContactDataProvider
    {
        private readonly DatabaseStorage _db;
        public ContactDataProviderMock()
        {
            _db = TestSession.Current.DatabaseStorage;
        }

        public void AddContat(Contact contact)
        {
            _db.Contacts.Add(contact.Id, contact);
        }

        public void DeleteContat(Guid id)
        {
            _db.Contacts.Remove(id);
        }

        public IList<Contact> GetContacts(string serachText)
        {
            IList<Contact> contacts;
            if (!String.IsNullOrWhiteSpace(serachText))
            {
                contacts = _db.Contacts.Values.Where(c =>
                c.FullName.Contains(serachText)
                || c.Nickname.Contains(serachText)
                || c.Address.Contains(serachText)
                || c.Company.Contains(serachText)).ToList();
            }
            else
            {
                contacts = _db.Contacts.Values.ToList();
            }
            return contacts;
        }

        public void UpdateContat(Contact contact)
        {
            _db.Contacts[contact.Id] = contact;
        }
    }
}
