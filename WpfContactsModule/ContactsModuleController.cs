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
    public class ContactsModuleController : BaseRegionController
    {
        IContainerProvider _container;
        IRegionManager _regionManager;
        public ContactsModuleController(IContainerProvider container,
                                 IRegionManager regionManager)
           : base(container, regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        internal void LoadView()
        {
            this._regionManager.RegisterViewWithRegion(RegionNames.MainWindowRegion, () => this._container.Resolve<ContactsView>());
            this._regionManager.RegisterViewWithRegion(ContactsRegionNames.ContactListRegion, () => this._container.Resolve<ContactListView>());
            this._regionManager.RegisterViewWithRegion(ContactsRegionNames.ContactDetailsRegion, () => this._container.Resolve<ContactDetailsView>());
        }
    }
}
