using Forecast.Core;
using Forecast.Core.Events;
using Forecast.Core.Menu;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Forecast.Module.Menu.ViewModels
{
    public class TopMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public ObservableCollection<MenuButton> Buttons { get; set; }

        public TopMenuViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            
            Buttons = new ObservableCollection<MenuButton>
            {
                new MenuButton { IsVisible = true, Content = ButtonTitles.Home, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Home },
                new MenuButton { Content = ButtonTitles.Enroll, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Enroll },
                new MenuButton { Content = ButtonTitles.Composition, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Composition },
                new MenuButton { Content = ButtonTitles.Quote, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Quote },
                new MenuButton { Content = ButtonTitles.Bdi, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Bdi },
                new MenuButton { Content = ButtonTitles.Abc, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Abc },
                new MenuButton { Content = ButtonTitles.Report, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Report },
                new MenuButton { Content = ButtonTitles.Settings, Command = new DelegateCommand<string>(ChangePage), Parameter = ModuleNames.Settings }
            };

            _regionManager.RequestNavigate(RegionNames.Content, ModuleNames.Home);
        }

        private void ChangePage(string pageName)
        {
            foreach (var button in Buttons)
            {
                if (button.Parameter == pageName)
                    button.IsVisible = true;
                else
                    button.IsVisible = false;
            }

            CollectionViewSource.GetDefaultView(Buttons).Refresh();

            _regionManager.RequestNavigate(RegionNames.Content, pageName);
            _eventAggregator.GetEvent<ChangeSubMenuButtonsEvent>().Publish(pageName);
        }
    }
}
