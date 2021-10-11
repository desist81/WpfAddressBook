using ClientInfrastructure;
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

        public DataState DataState { get; set; }

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

        internal override void BeforePropertyChangedNotification(bool isPropertyValueChanged)
        {
            if (this.DataState == DataState.Undefined) this.DataState = DataState.Modified;
            base.OnPropertyChangedNotification(isPropertyValueChanged);
        }

        internal override void OnPropertyChangedNotification(bool isPropertyValueChanged)
        {
            base.OnPropertyChangedNotification(isPropertyValueChanged);
        }
    }
}
