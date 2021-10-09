using DataProviderInterfates;
using DomainModel;
using RealmDataProviders.Entities;
using RealmDataProviders.Translators;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDataProviders
{
    public class ContactDataProvider : DataProvider, IContactDataProvider
    {
        public void AddContat(Contact contact)
        {
            RContact rContact = Map.Mapper.Map<RContact>(contact);
            RealmInstance.Write(() =>
              {
                  RealmInstance.Add(rContact);
              });
        }

        public void DeleteContat(Guid id)
        {
            RContact contactToDelete = RealmInstance.Find<RContact>(id);

            RealmInstance.Write(() =>
            {
                RealmInstance.Remove(contactToDelete);
            });
        }

        public IList<Contact> GetContacts(string serachText)
        {
            IQueryable<RContact> rContacts;
            //Ask about culture info, collations, case sensitive compare
            rContacts = RealmInstance.All<RContact>().Where(c => c.FullName.Contains(serachText));
            List<Contact> contacts = rContacts.ToList().Select(c => Map.Mapper.Map<Contact>(c)).ToList();

            return contacts;
        }

        public void UpdateContat(Contact contact)
        {
            RealmInstance.Write(() =>
             {
                 RContact contactToUpdate = RealmInstance.Find<RContact>(contact.Id);
                 Map.Mapper.Map(contact, contactToUpdate);
             });
        }
    }
}
