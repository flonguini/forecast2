using AutoMapper;
using Forecast.Domain.Entities.Enroll;
using Forecast.Domain.Handlers.Enroll;
using Forecast.Domain.Repositories;
using Forecast.Infra.Repositories;
using Forecast.Module.Abc;
using Forecast.Module.Bdi;
using Forecast.Module.Composition;
using Forecast.Module.Enroll;
using Forecast.Module.Home;
using Forecast.Module.Menu;
using Forecast.Module.Quote;
using Forecast.Module.Report;
using Forecast.Module.Settings;
using Forecast.Module.Shared;
using Forecast.Modules.Statusbar;
using Forecast.Wpf.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Forecast.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell() => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IClientHandler, ClientHandler>();
            containerRegistry.Register<IClientRepository, ClientRepository>();
            containerRegistry.Register<Client>();

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ClientDto, Client>();
            //});

            //var mapper = config.CreateMapper();

            //containerRegistry.RegisterInstance(typeof(IMapper), mapper);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AbcModule>();
            moduleCatalog.AddModule<BdiModule>();
            moduleCatalog.AddModule<CompositionModule>();
            moduleCatalog.AddModule<EnrollModule>();
            moduleCatalog.AddModule<HomeModule>();
            moduleCatalog.AddModule<MenuModule>();
            moduleCatalog.AddModule<QuoteModule>();
            moduleCatalog.AddModule<ReportModule>();
            moduleCatalog.AddModule<SettingsModule>();
            moduleCatalog.AddModule<SharedModule>();
            moduleCatalog.AddModule<StatusbarModule>();
        }
    }
}
