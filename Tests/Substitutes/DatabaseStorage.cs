using System;
using System.Collections.Generic;
using System.Linq;

namespace Substitutes
{
    public class DatabaseStorage
    {
        Dictionary<Guid, DomainModel.Contact> _contactDatabase = new Dictionary<Guid, DomainModel.Contact>();
        Dictionary<Guid, DomainModel.ContactField> _contactFieldsDatabase = new Dictionary<Guid, DomainModel.ContactField>();
     
        public DatabaseStorage()
        {
        }

        public Dictionary<Guid, DomainModel.Contact> Contacts
        {
            get
            {
                return _contactDatabase;
            }
        }

        public Dictionary<Guid, DomainModel.ContactField> ContactFields
        {
            get
            {
                return _contactFieldsDatabase;
            }
        }

       
    }
}
