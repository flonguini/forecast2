using Forecast.Core;
using Forecast.Module.Enroll.ViewModels;
using Forecast.Module.Enroll.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Enroll
{
    public class EnrollModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public EnrollModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Enroll, typeof(EnrollHome));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<EnrollHome, EnrollHomeViewModel>(ModuleNames.Enroll);
        }
    }
}