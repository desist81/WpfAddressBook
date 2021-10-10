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
    public class ContactFieldDataProviderMock : DataProvider, IContactFieldDataProvider
    {
        DatabaseStorage _db;
        public ContactFieldDataProviderMock()
        {
            _db = TestSession.Current.DatabaseStorage;
        }

        public void AddContactField(ContactField field)
        {
            _db.ContactFields.Add(field.Id, field);
        }

        public void DeleteContactField(Guid id)
        {
            _db.ContactFields.Remove(id);
        }

      
    }
}
