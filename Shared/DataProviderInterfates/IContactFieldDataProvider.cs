using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProviderInterfates
{
    public interface IContactFieldDataProvider : IDataProvider
    {
        void DeleteContactField(Guid id);
        void AddContactField(ContactField field);
    }
}
