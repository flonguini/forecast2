using Forecast.Core;
using Forecast.Module.Quote.ViewModels;
using Forecast.Module.Quote.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Forecast.Module.Quote
{
    public class QuoteModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public QuoteModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(ModuleNames.Quote, typeof(QuoteHome));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<QuoteHome, QuoteHomeViewModel>(ModuleNames.Quote);
        }
    }
}