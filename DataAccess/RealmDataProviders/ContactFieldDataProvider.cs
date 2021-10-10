using DataProviderInterfates;
using DomainModel;
using RealmDataProviders.Entities;
using RealmDataProviders.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDataProviders
{
    public class ContactFieldDataProvider : DataProvider, IContactFieldDataProvider
    {
        public void AddContactField(ContactField field)
        {
            RContactField rContact = Map.Mapper.Map<RContactField>(field);
            RealmInstance.Write(() =>
            {
                RealmInstance.Add(rContact);
            });
        }

        public void DeleteContactField(Guid id)
        {
            RContactField fieldToDelete = RealmInstance.Find<RContactField>(id);

            RealmInstance.Write(() =>
            {
                RealmInstance.Remove(fieldToDelete);
            });
        }

    }
}
