using Forecast.Core;
using Forecast.Module.Abc.ViewModels;
using Forecast.Module.Abc.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Abc
{
    public class AbcModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AbcModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Abc, typeof(AbcHome));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AbcHome, AbcHomeViewModel>(ModuleNames.Abc);
        }
    }
}