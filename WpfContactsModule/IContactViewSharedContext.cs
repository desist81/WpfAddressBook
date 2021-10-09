using ClientInfrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule
{
    public interface IContactViewSharedContext : IViewSharedContext
    {
        int CurrentIndex { get; set; }
        INotifyPropertyChanged EditItem { get; set; }
    }
}
