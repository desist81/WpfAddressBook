using ClientInfrastructure;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public class ContactBindingEntity : NotifyBindingEntityProperyChanged<Contact>
    {
        ObservableCollection<ContactFieldBindingEntity> _fieldsCollection;

        public ContactBindingEntity(Contact domainEntity) :
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
                    FirePropertyChanged(nameof(FullName));
                }
            }
        }

        public string Nickname
        {
            get
            {
                return DomainEntity.Nickname;
            }
            set
            {
                if (base.CheckPropertyChanged<string>(DomainEntity.Nickname, value))
                {
                    DomainEntity.Nickname = value;
                    FirePropertyChanged(nameof(Nickname));
                }
            }
        }

        public string Address
        {
            get
            {
                return DomainEntity.Address;
            }
            set
            {
                if (base.CheckPropertyChanged<string>(DomainEntity.Address, value))
                {
                    DomainEntity.Address = value;
                    FirePropertyChanged(nameof(Address));
                }
            }
        }

        public string Company
        {
            get
            {
                return DomainEntity.Company;
            }
            set
            {
                if (base.CheckPropertyChanged<string>(DomainEntity.Company, value))
                {
                    DomainEntity.Company = value;
                    FirePropertyChanged(nameof(Company));
                }
            }
        }
        public ObservableCollection<ContactFieldBindingEntity> Fields
        {
            get
            {
                if (_fieldsCollection == null)
                {
                    _fieldsCollection = new ObservableCollection<ContactFieldBindingEntity>(
                        DomainEntity.Fields.Select(f => new ContactFieldBindingEntity(f)));
                }
                return _fieldsCollection;
            }
            set
            {
                if (_fieldsCollection != value)
                {
                    _fieldsCollection = value;
                    FirePropertyChanged(nameof(Fields), false);
                }
            }
        }

        public void NotifyContactFieldsChanged()
        {
            FirePropertyChanged(nameof(Fields), true);
        }
        public override bool Validate()
        {
            if (String.IsNullOrWhiteSpace(this.FullName))
                AddError(nameof(FullName), "Required field");
            else
                ClearErrors(nameof(FullName));
            return !HasErrors;
        }
    }
}
