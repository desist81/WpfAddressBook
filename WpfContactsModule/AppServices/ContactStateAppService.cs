using AppServiceInterfaces;
using ClientModel;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule.AppServices
{
    public class ContactStateAppService : IContactStateAppService
    {
        public bool IsEditMode { get; set; }
    }
    
}
