using Forecast.Domain.Commands.Contracts;
using Prism.Events;
using Prism.Mvvm;
using System.Windows.Media;
using Forecast.Domain.Emuns;
using Forecast.Core.Events;

namespace Forecast.Modules.Statusbar.ViewModels
{
    public class StatusbarViewModel : BindableBase
    {
        #region Constants

        private static readonly SolidColorBrush BLUE = new SolidColorBrush(Color.FromRgb(0, 122, 204));
        private static readonly SolidColorBrush ORANGE = new SolidColorBrush(Color.FromRgb(202, 81, 0));
        private static readonly SolidColorBrush RED = new SolidColorBrush(Color.FromRgb(216, 24, 44));
        private static readonly SolidColorBrush GREEN = new SolidColorBrush(Color.FromRgb(34, 156, 3));

        #endregion

        #region Private Members

        private double _height;
        private string _message;
        private bool _isProgressVisible;
        private SolidColorBrush _background;

        #endregion

        #region Public Properties

        public double Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public bool IsProgressVisible
        {
            get => _isProgressVisible;
            set => SetProperty(ref _isProgressVisible, value);
        }

        public SolidColorBrush Background
        {
            get => _background;
            set => SetProperty(ref _background, value);
        }

        #endregion

        #region Constructors

        public StatusbarViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<StatusBarEvent>().Subscribe(StatusBarChangedEvent);
            eventAggregator.GetEvent<StatusBarStatusEvent>().Subscribe(ChangeStatusBarColor);

            Height = 25;
            Message = "Tudo pronto";
            IsProgressVisible = false;
            Background = BLUE;
        }

        #endregion

        #region Private Methods

        private void StatusBarChangedEvent(ICommandResult commandResult)
        {
            Message = commandResult.Message;

            if (!commandResult.Success)
            {
                ChangeStatusBarColor(StatusBarState.Error);
                return;
            }

            ChangeStatusBarColor(StatusBarState.Complete);
        }

        private void ChangeStatusBarColor(StatusBarState status)
        {
            switch (status)
            {
                case StatusBarState.Complete:
                    IsProgressVisible = false;
                    Background = BLUE;
                    break;
                case StatusBarState.Waiting:
                    IsProgressVisible = true;
                    Message = "Aguarde...";
                    Background = ORANGE;
                    break;
                case StatusBarState.Error:
                    IsProgressVisible = false;
                    Background = RED;
                    break;
                default:
                    IsProgressVisible = false;
                    Background = BLUE;
                    break;
            }
        }

        #endregion
    }
}
