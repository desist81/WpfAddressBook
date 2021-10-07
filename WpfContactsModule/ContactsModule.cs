using AppServiceInterfaces;
using ClientInfrastructure;
using ClientInfrastructure.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfContactsModule.AppServices;
using WpfContactsModule.ViewModels;
using WpfContactsModule.Views;

namespace WpfContactsModule
{
    public class ContactsModule : IContactModule
    {
        ContactsModuleController _moduleController;

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IContactModule>(this);
            containerRegistry.RegisterInstance<IContactViewSharedContext>(new ContactViewSharedContext(ModuleNames.ContactsModule));
            containerRegistry.Register<IContactRepositoryAppService, ContactRepositoryAppService>();
            containerRegistry.RegisterInstance<IContactStateAppService>(new ContactStateAppService(), ModuleNames.ContactsModule);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            RegisterViews(containerProvider);
            _moduleController = containerProvider.Resolve<ContactsModuleController>();
            _moduleController.ModuleName = ModuleNames.ContactsModule;
           
            _moduleController.LoadView();
        }

        private static void RegisterViews(IContainerProvider containerProvider)
        {
            ViewModelLocationProvider.Register<ContactListView, ContactListViewModel>();
            ViewModelLocationProvider.Register<ContactDetailsView,ContactDetailsViewModel>();
        }
    }
}
