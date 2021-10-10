using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInfrastructure
{
    public abstract class BaseRegionController
    {
        public readonly IContainerProvider _container;
        public readonly IRegionManager _regionManager;


        public BaseRegionController(IContainerProvider container,
                                   IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public string ModuleName { get; set; }
    }
}
