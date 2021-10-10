using ClientInfrastructure;
using ClientInfrastructure.Constants;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfContactsModule.Constants;
using WpfContactsModule.Views;

namespace WpfContactsModule
{
    public sealed class ContactsModuleController : BaseRegionController
    {
       
        public ContactsModuleController(IContainerProvider container,
                                 IRegionManager regionManager)
           : base(container, regionManager)
        {
           
        }

        public void LoadView()
        {
            this._regionManager.RegisterViewWithRegion(RegionNames.MainWindowRegion, () => this._container.Resolve<ContactsView>());
            this._regionManager.RegisterViewWithRegion(ContactsRegionNames.ContactListRegion, () => this._container.Resolve<ContactListView>());
            this._regionManager.RegisterViewWithRegion(ContactsRegionNames.ContactDetailsRegion, () => this._container.Resolve<ContactDetailsView>());
        }
    }
}
