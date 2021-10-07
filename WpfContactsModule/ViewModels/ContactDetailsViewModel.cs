using AppServiceInterfaces;
using ClientInfrastructure.ViewModelsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule.ViewModels
{
    public class ContactDetailsViewModel : BaseNotificationViewModel
    {
        IContactStateAppService _moduleState;
        IContactRepositoryAppService _repository;
        public ContactDetailsViewModel(IContactModule module,
            IContactViewSharedContext context,
            IContactStateAppService moduleState,
            IContactRepositoryAppService repository)
           : base(module)
        {
            _moduleState = moduleState;
            _repository = repository;
            this.RegionContext = context;
    
        }
    }
}
