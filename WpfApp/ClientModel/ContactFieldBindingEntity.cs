using ClientInfrastructure;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public class ContactFieldBindingEntity : NotifyBindingEntityProperyChanged<ContactField>
    {

        public ContactFieldBindingEntity(ContactField domainEntity) :
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

        public string Content
        {
            get
            {
                return DomainEntity.Content;
            }
            set
            {
                if (base.CheckPropertyChanged<string>(DomainEntity.Content, value))
                {
                    DomainEntity.Content = value;
                    FirePropertyChanged(nameof(Content));
                }
            }
        }

        public FieldType FieldType
        {
            get
            {
                return DomainEntity.FieldType;
            }
            set
            {
                if (base.CheckPropertyChanged<FieldType>(DomainEntity.FieldType, value))
                {
                    DomainEntity.FieldType = value;
                    FirePropertyChanged(nameof(FieldType));
                }
            }
        }

    }
}
