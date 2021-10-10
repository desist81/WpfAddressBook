using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfrastructure
{
    public interface IViewSharedContext : INotifyPropertyChanged
    {
        event EventHandler IsModuleActiveChanged;

        string ModuleName { get; }

        bool IsModuleActive { get; set; }
        INotifyPropertyChanged CurrentItem { get; set; }
    }
}
