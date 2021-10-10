using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProviderInterfates
{
    public interface IContactDataProvider : IDataProvider
    {
        IList<Contact> GetContacts(string serachText);
        void UpdateContat(Contact contact);
        void DeleteContat(Guid id);
        void AddContat(Contact contact);
    }
}
