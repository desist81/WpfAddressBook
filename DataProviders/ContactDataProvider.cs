using DataProviderInterfates;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProviders
{
    public class ContactDataProvider : IContactDataProvider
    {
        public void AddContat(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteContat(Guid id)
        {
            throw new NotImplementedException();
        }

        public void GetContacts(string serachText)
        {
            throw new NotImplementedException();
        }

        public void UpdateContat(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
