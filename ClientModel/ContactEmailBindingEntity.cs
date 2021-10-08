using ClientInfrastructure;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public class ContactEmailBindingEntity : NotifyBindingEntityProperyChanged<ContactEmail>
    {

        public ContactEmailBindingEntity(ContactEmail domainEntity) :
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
                    FirePropertyChanged(this.GetMemberName(p => p.Id));
                }
            }
        }

        public string Email
        {
            get
            {
                return DomainEntity.Email;
            }
            set
            {
                if (base.CheckPropertyChanged<string>(DomainEntity.Email, value))
                {
                    DomainEntity.Email = value;
                    FirePropertyChanged(this.GetMemberName(p => p.Email));
                }
            }
        }

    }
}
