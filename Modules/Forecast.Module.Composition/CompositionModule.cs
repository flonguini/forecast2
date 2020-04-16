using Forecast.Core;
using Forecast.Module.Composition.ViewModels;
using Forecast.Module.Composition.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Composition
{
    public class CompositionModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public CompositionModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Composition, typeof(CompositionHome));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CompositionHome, CompositionHomeViewModel>(ModuleNames.Composition);
        }
    }
}