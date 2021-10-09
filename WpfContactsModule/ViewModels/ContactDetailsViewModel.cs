using AppServiceInterfaces;
using ClientInfrastructure.ViewModelsBase;
using ClientModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule.ViewModels
{
    public class ContactDetailsViewModel : BaseNotificationViewModel
    {
        public ContactDetailsViewModel(IContactModule module,
             IContactViewSharedContext context)
            : base(module)
        {

            this.RegionContext = context;

        }

    }
}
