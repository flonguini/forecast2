using Forecast.Core;
using Forecast.Core.Events;
using Forecast.Core.Menu;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Forecast.Module.Menu.ViewModels
{
    public class BottomMenuViewModel : BindableBase
    {
        public ObservableCollection<MenuButton> Buttons { get; set; }

        public BottomMenuViewModel(IEventAggregator eventAggregator)
        {
            Buttons = new ObservableCollection<MenuButton>();
            eventAggregator.GetEvent<ChangeSubMenuButtonsEvent>().Subscribe(ChangeSubMenuButtons);
        }

        private void ChangeSubMenuButtons(string pageName)
        {
            Buttons.Clear();

            switch (pageName)
            {
                case ModuleNames.Home:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Dashboard", Command = null, Parameter = "" });
                    break;
                case ModuleNames.Enroll:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Clientes", Command = null, Parameter = "" });
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Obras", Command = null, Parameter = "" });
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Profissionais", Command = null, Parameter = "" });
                    break;
                case ModuleNames.Composition:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Pesquisar", Command = null, Parameter = "" });
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Personalizada", Command = null, Parameter = "" });
                    break;
                case ModuleNames.Quote:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Adicionar Etapa", Command = null, Parameter = "" });
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Criar Cotação", Command = null, Parameter = "" });
                    break;
                case ModuleNames.Bdi:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "BDI", Command = null, Parameter = "" });
                    break;
                case ModuleNames.Abc:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Curva ABC de Etapas", Command = null, Parameter = "" });
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Curva ABC de Itens", Command = null, Parameter = "" });
                    break;
                case ModuleNames.Planning:
                    break;
                case ModuleNames.Report:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Relatórios", Command = null, Parameter = "" });
                    break;
                case ModuleNames.Settings:
                    Buttons.Add(new MenuButton { IsVisible = true, Content = "Configurações", Command = null, Parameter = "" });
                    break;
                default:
                    break;
            }
        }
    }
}
