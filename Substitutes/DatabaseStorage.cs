using System;
using System.Collections.Generic;
using System.Linq;

namespace Substitutes
{
    public class DatabaseStorage
    {
        Dictionary<Guid, DomainModel.Contact> _contactDatabase = new Dictionary<Guid, DomainModel.Contact>();
        Dictionary<Guid, DomainModel.ContactEmail> _contactEmailDatabase = new Dictionary<Guid, DomainModel.ContactEmail>();
        Dictionary<Guid, DomainModel.ContactPhone> _contactPhoneDatabase = new Dictionary<Guid, DomainModel.ContactPhone>();

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

        public Dictionary<Guid, DomainModel.ContactEmail> ContactEmails
        {
            get
            {
                return _contactEmailDatabase;
            }
        }

        public Dictionary<Guid, DomainModel.ContactPhone> ContactPhones
        {
            get
            {
                return _contactPhoneDatabase;
            }
        }
    }
}
