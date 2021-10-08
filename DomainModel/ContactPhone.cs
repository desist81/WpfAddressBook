using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class ContactPhone: BaseEntity
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }

    }
}
