using Prism.Mvvm;

namespace Forecast.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public double MinHeight { get; set; } = 820;
        public double MinWidth { get; set; } = 1280;
        public string Title { get; set; } = "Forecast Orçamentos";

        public MainWindowViewModel()
        {

        }
    }
}
