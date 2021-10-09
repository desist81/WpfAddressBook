using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class ContactEmail : BaseEntity
    {
        public ContactEmail()
        {

        }
        public Guid Id { get; set; }
        public string Email { get; set; }

        //public Contact Contact { get; set; }

    }
}
