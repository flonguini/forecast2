using Forecast.Module.Shared.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Shared
{
    public class SharedModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SharedModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}