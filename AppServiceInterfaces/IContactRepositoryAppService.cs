﻿using ClientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceInterfaces
{
    public interface IContactRepositoryAppService
    {
        ObservableCollection<ContactBindingEntity> GetContactsCollection();
    }
}
