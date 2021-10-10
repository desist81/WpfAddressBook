using AppServiceInterfaces;
using ClientInfrastructure.Constants;
using DataProviderInterfates;
using NSubstitute;
using Prism.Ioc;
using Prism.Mvvm;
using Substitutes.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfContactsModule;
using WpfContactsModule.AppServices;
using WpfContactsModule.ViewModels;
using WpfContactsModule.Views;

namespace Substitutes.ContactModule
{
    public static class ContactModuleFactory
    {
        public static IContactModule FakeInstance()
        {
            IContactModule module = Substitute.For<IContactModule>();
            Init(module);
            return module;
        }

        public static void Init(IContactModule module)
        {
            module.When(x => x.RegisterTypes(Arg.Any<IContainerRegistry>()))
            .Do(info =>
            {
                IContainerRegistry containerRegistry = info.Arg<IContainerRegistry>();

                containerRegistry.RegisterInstance<IContactModule>(module);
                containerRegistry.RegisterInstance<IContactViewSharedContext>(new ContactViewSharedContext(ModuleNames.ContactsModule));
                containerRegistry.Register<IContactRepositoryAppService, ContactRepositoryAppService>();
                containerRegistry.RegisterSingleton<IContactStateAppService, ContactStateAppService>();
                containerRegistry.Register<IContactDataProvider, ContactDataProviderMock>();

            });


            module.When(x => x.OnInitialized(Arg.Any<IContainerProvider>()))
            .Do(info =>
             {
                 IContainerProvider containerProvider = info.Arg<IContainerProvider>();

                 ViewModelLocationProvider.Register<ContactListView, ContactListViewModel>();
                 ViewModelLocationProvider.Register<ContactDetailsView, ContactDetailsViewModel>();
                 ContactsModuleController moduleController = containerProvider.Resolve<ContactsModuleController>();
                 moduleController.ModuleName = ModuleNames.ContactsModule;

                 moduleController.LoadView();
             });

               }
    }
}