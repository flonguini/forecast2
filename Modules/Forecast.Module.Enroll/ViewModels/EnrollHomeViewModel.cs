using AutoMapper;
using Forecast.Core.Events;
using Forecast.Domain.Commands.Enroll;
using Forecast.Domain.Emuns;
using Forecast.Domain.Entities.Enroll;
using Forecast.Domain.Handlers.Enroll;
using Prism.Commands;
using Prism.Events;

namespace Forecast.Module.Enroll.ViewModels
{
    public class EnrollHomeViewModel : BaseViewModel
    {
        #region Private Members

        private readonly IMapper _mapper;
        private readonly IClientHandler _clientHandle;
        private readonly IEventAggregator _eventAggregator;
        private string _fullName;
        private string _phone;
        private string _cellPhone;
        private string _email;
        private string _cpf;
        private string _rg;
        private Client _client;


        #endregion

        #region Public Properties

        public DelegateCommand SaveCommand { get; set; }
        public string FullName
        {
            get => _fullName;
            set
            {
                SetProperty(ref _fullName, value);
                ValidateUserName(nameof(FullName), value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                SetProperty(ref _phone, value);
                ValidatePhone(nameof(Phone), value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string CellPhone
        {
            get => _cellPhone;
            set
            {
                SetProperty(ref _cellPhone, value);
                ValidateCellPhone(nameof(CellPhone), value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                ValidateEmail(nameof(Email), value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string Cpf
        {
            get => _cpf;
            set
            {
                SetProperty(ref _cpf, value);
                ValidateCpf(nameof(Cpf), value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string Rg
        {
            get => _rg;
            set
            {
                SetProperty(ref _rg, value);
                ValidateRg(nameof(Rg), value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Constructors

        public EnrollHomeViewModel(IEventAggregator eventAggregator, IClientHandler clientHandle, Client client)
        {
            _eventAggregator = eventAggregator;
            _clientHandle = clientHandle;
            _client = client;
            SaveCommand = new DelegateCommand(Save, CanExecute);
        }

        #endregion

        #region Private Methods

        private bool CanExecute() => !HasErrors;
        private void Save()
        {

            _client.ChangeFullName(FullName);
            _client.ChangePhone(Phone);
            _client.ChangeCellPhone(CellPhone);
            _client.ChangeEmail(Email);
            _client.ChangeCpf(Cpf);
            _client.ChangeRg(Rg);

            _eventAggregator.GetEvent<StatusBarStatusEvent>().Publish(StatusBarState.Waiting);

            var command = new CreateClientCommand(_client);

            var handleResult = _clientHandle.Handle(command);

            FullName = _client.FullName;
            Phone = _client.Phone;
            CellPhone = _client.CellPhone;
            Email = _client.Email;
            Cpf = _client.Cpf;
            Rg = _client.Rg;

            _eventAggregator.GetEvent<StatusBarEvent>().Publish(handleResult);
        }

        #endregion
    }
}
