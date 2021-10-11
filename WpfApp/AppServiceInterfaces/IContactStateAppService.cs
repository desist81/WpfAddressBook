using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceInterfaces
{
    public interface IContactStateAppService
    {
        bool IsEditMode { get; set; }   
    }
}
