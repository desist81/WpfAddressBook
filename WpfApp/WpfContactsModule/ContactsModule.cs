using AppServiceInterfaces;
using ClientInfrastructure;
using ClientInfrastructure.Constants;
using DataProviderInterfates;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using RealmDataProviders;
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
    public sealed class ContactsModule : IContactModule
    {

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IContactModule>(this);
            containerRegistry.RegisterInstance<IContactViewSharedContext>(new ContactViewSharedContext(ModuleNames.ContactsModule));
            containerRegistry.Register<IContactRepositoryAppService, ContactRepositoryAppService>();
            containerRegistry.RegisterSingleton<IContactStateAppService, ContactStateAppService>();
            containerRegistry.Register<IContactDataProvider, ContactDataProvider>();
            containerRegistry.Register<IContactFieldDataProvider, ContactFieldDataProvider>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            RegisterViews(containerProvider);
            ContactsModuleController moduleController = containerProvider.Resolve<ContactsModuleController>();
            moduleController.ModuleName = ModuleNames.ContactsModule;

            moduleController.LoadView();
        }

        private static void RegisterViews(IContainerProvider containerProvider)
        {
            ViewModelLocationProvider.Register<ContactListView, ContactListViewModel>();
            ViewModelLocationProvider.Register<ContactDetailsView, ContactDetailsViewModel>();
        }
    }
}
