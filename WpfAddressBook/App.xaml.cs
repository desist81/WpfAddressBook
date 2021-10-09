using AppServiceInterfaces;
using ClientInfrastructure.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Windows;
using WpfAddressBook.Views;
using WpfContactsModule;
using WpfContactsModule.AppServices;

namespace WpfAddressBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var shell = Container.Resolve<ShellWindow>();
            return shell;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
         
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
                     
            base.ConfigureModuleCatalog(moduleCatalog);

            Type moduleCType = typeof(ContactsModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = ModuleNames.ContactsModule,
                ModuleType = moduleCType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }
    }
}
