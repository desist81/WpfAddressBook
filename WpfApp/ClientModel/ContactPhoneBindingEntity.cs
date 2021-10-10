using ClientInfrastructure;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public class ContactPhoneBindingEntity : NotifyBindingEntityProperyChanged<ContactPhone>
    {

        public ContactPhoneBindingEntity(ContactPhone domainEntity) :
            base(domainEntity)
        {
        }

        public Guid Id
        {
            get
            {
                return DomainEntity.Id;
            }
            set
            {
                if (base.CheckPropertyChanged<Guid>(DomainEntity.Id, value))
                {
                    DomainEntity.Id = value;
                    FirePropertyChanged(nameof(Id));
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return DomainEntity.PhoneNumber;
            }
            set
            {
                if (base.CheckPropertyChanged<string>(DomainEntity.PhoneNumber, value))
                {
                    DomainEntity.PhoneNumber = value;
                    FirePropertyChanged(nameof(PhoneNumber));
                }
            }
        }

    }
}
