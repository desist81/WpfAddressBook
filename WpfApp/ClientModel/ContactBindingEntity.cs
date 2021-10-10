using ClientInfrastructure;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public class ContactBindingEntity : NotifyBindingEntityProperyChanged<Contact>
    {
        ObservableCollection<ContactPhoneBindingEntity> _phoneNumbersCollection;
        ObservableCollection<ContactEmailBindingEntity> _emailsCollection;

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
        public ObservableCollection<ContactPhoneBindingEntity> PhoneNumbers
        {
            get
            {
                if (_phoneNumbersCollection == null)
                {
                    _phoneNumbersCollection = new ObservableCollection<ContactPhoneBindingEntity>(
                        DomainEntity.PhoneNumbers.Select(p => new ContactPhoneBindingEntity(p)));
                }
                return _phoneNumbersCollection;
            }
            set
            {
                if (_phoneNumbersCollection != value)
                {
                    _phoneNumbersCollection = value;
                    FirePropertyChanged(nameof(PhoneNumbers), false);
                }
            }
        }

        public ObservableCollection<ContactEmailBindingEntity> Emails
        {
            get
            {
                if (_emailsCollection == null)
                {
                    _emailsCollection = new ObservableCollection<ContactEmailBindingEntity>(
                        DomainEntity.Emails.Select(p => new ContactEmailBindingEntity(p)));
                }
                return _emailsCollection;
            }
            set
            {
                if (_emailsCollection != value)
                {
                    _emailsCollection = value;
                    FirePropertyChanged(nameof(Emails), false);
                }
            }
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
