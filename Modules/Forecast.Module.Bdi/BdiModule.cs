using Forecast.Core;
using Forecast.Module.Bdi.ViewModels;
using Forecast.Module.Bdi.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Bdi
{
    public class BdiModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public BdiModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Bdi, typeof(BdiHome));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BdiHome, BdiHomeViewModel>(ModuleNames.Bdi);
        }
    }
}