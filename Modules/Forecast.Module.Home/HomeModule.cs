using Forecast.Core;
using Forecast.Module.Home.ViewModels;
using Forecast.Module.Home.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Home
{
    public class HomeModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public HomeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Home, typeof(Dashboard));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Dashboard, DashboardViewModel>(ModuleNames.Home);
        }
    }
}