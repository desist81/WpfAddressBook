using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
   
    public class Contact : BaseEntity
    {
        public Contact()
        {
            PhoneNumbers = new List<ContactPhone>();
            Emails = new List<ContactEmail>();
        }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public IList<ContactPhone> PhoneNumbers { get; }
        public IList<ContactEmail> Emails { get; }
    }
}
