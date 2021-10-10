using Prism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfrastructure.ViewModelsBase
{
    public interface IViewModel : IActiveAware
    {
        IBaseModule Module { get; }
        IViewSharedContext RegionContext { get; set; }
     }
}
