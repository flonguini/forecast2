using Forecast.Core;
using Forecast.Module.Report.ViewModels;
using Forecast.Module.Report.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Report
{
    public class ReportModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ReportModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Report, typeof(ReportHome));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ReportHome, ReportHomeViewModel>(ModuleNames.Report);
        }
    }
}