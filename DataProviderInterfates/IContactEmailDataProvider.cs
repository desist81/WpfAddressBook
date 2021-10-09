using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProviderInterfates
{
    public interface IContactEmailDataProvider : IDataProvider
    {
        void DeleteContatEmail(Guid id);
        void UpdateContatEmail(ContactEmail email);
        void AddContatEmail(ContactEmail email);
    }
}
