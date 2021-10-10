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
        private ContactBindingEntity _contact;
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


        public ContactBindingEntity Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactBindingEntity(DomainEntity.Contact);
                }
                    return _contact;
            }
            set
            {
                if (base.CheckPropertyChanged<ContactBindingEntity>(_contact, value))
                {
                    _contact = value;
                    DomainEntity.Contact = _contact.DomainEntity;
                    FirePropertyChanged(nameof(Contact));
                }
            }
        }

    }
}
