using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Contact : BaseEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public List<ContactPhone> PhoneNumbers { get; set; }
        public List<ContactEmail> Emails { get; set; }
    }
}
