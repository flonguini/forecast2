using Forecast.Core;
using Forecast.Module.Menu.ViewModels;
using Forecast.Module.Menu.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Menu
{
    public class MenuModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MenuModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.TopMenu, typeof(TopMenu));
            _regionManager.RegisterViewWithRegion(RegionNames.BottomMenu, typeof(BottomMenu));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TopMenu, TopMenuViewModel>(RegionNames.TopMenu);
            containerRegistry.RegisterForNavigation<BottomMenu, BottomMenuViewModel>(RegionNames.BottomMenu);
        }
    }
}