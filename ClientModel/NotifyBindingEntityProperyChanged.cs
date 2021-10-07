using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel
{
    public abstract class NotifyBindingEntityProperyChanged<TEntity> : NotifyProperyChangedBase
      where TEntity : BaseEntity
    {
        protected TEntity _domainEntity;
      

        public NotifyBindingEntityProperyChanged()
            : base()
        {
            _domainEntity = Activator.CreateInstance(typeof(TEntity), null) as TEntity;
        }

        public NotifyBindingEntityProperyChanged(TEntity domainEntity)
        {
            _domainEntity = domainEntity;
        }

        public TEntity DomainEntity
        {
            get
            {
                return _domainEntity;
            }
        }

    }
}
