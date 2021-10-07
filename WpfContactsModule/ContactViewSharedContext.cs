using ClientInfrastructure;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule
{
    internal class ContactViewSharedContext : ViewSharedContext, IContactViewSharedContext
    {
        public ContactViewSharedContext(string moduleName) : base(moduleName)
        {

        }

    }
}
