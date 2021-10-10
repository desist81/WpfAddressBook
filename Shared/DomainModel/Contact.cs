using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel
{
   
    public class Contact : BaseEntity
    {
        public Contact()
        {
            Fields = new List<ContactField>();
        }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public IList<ContactField> Fields { get; }
    }
}
