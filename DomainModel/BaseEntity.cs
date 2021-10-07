using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
        }

        public virtual bool IsEmpty()
        {
            return false;
        }
    }

}
