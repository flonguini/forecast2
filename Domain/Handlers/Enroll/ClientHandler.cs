using Flunt.Notifications;
using Forecast.Domain.Commands;
using Forecast.Domain.Commands.Contracts;
using Forecast.Domain.Commands.Enroll;
using Forecast.Domain.Entities.Enroll;
using Forecast.Domain.Handlers.Contracts;
using Forecast.Domain.Repositories;

namespace Forecast.Domain.Handlers.Enroll
{
    public class ClientHandler : Notifiable, 
        IHandler<CreateClientCommand>, 
        IHandler<UpdateClientCommand>, 
        IClientHandler
    {
        private readonly IClientRepository _clientRepository;

        public ClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ICommandResult Handle(CreateClientCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possível criar o cliente", command.Notifications);

            var client = new Client();

            _clientRepository.Create(client);

            return new GenericCommandResult(true, "Cliente criado com sucesso", client);
        }

        public ICommandResult Handle(UpdateClientCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Não foi possível atualizar o cliente", command.Notifications);

            var client = _clientRepository.GetClientById(command.ClientId);

            client.ChangeCellPhone(command.CellPhone);
            client.ChangeCpf(command.Cpf);
            client.ChangeEmail(command.Email);
            client.ChangeFullName(command.FullName);
            client.ChangeRg(command.Rg);
            client.ChangePhone(command.Phone);

            _clientRepository.Update(client);

            return new GenericCommandResult(true, "Cliente atualizado com sucesso", client);
        }
    }
}
