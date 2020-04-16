using Forecast.Core;
using Forecast.Module.Settings.ViewModels;
using Forecast.Module.Settings.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Settings
{
    public class SettingsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public SettingsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Settings, typeof(SettingsHome));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SettingsHome, SettingsHomeViewModel>(ModuleNames.Settings);
        }
    }
}