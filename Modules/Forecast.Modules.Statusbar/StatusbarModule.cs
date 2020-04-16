using Forecast.Modules.Statusbar.ViewModels;
using Forecast.Modules.Statusbar.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Modules.Statusbar
{
    public class StatusbarModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public StatusbarModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("StatusBar", typeof(StatusbarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StatusbarView, StatusbarViewModel>("StatusBar");
        }
    }
}