using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfrastructure
{
    public enum DataState: byte
    {
        Undefined,
        Added,
        Modified,
        Deleted
    }
}
