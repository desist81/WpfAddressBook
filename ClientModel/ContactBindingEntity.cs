using ClientInfrastructure;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public class ContactBindingEntity : NotifyBindingEntityProperyChanged<Contact>
    {

        public ContactBindingEntity(Contact domainEntity) :
            base(domainEntity)
        {
        }

        #region Primitive Properties
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

        public string FullName
        {
            get
            {
                return DomainEntity.FullName;
            }
            set
            {
                if (base.CheckPropertyChanged<string>(DomainEntity.FullName, value))
                {
                    DomainEntity.FullName = value;
                    FirePropertyChanged(this.GetMemberName(p => p.FullName));
                }
            }
        }

        #endregion Primitive Properties
    }
}
