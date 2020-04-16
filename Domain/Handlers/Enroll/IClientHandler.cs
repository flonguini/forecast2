using Forecast.Domain.Commands.Contracts;
using Forecast.Domain.Commands.Enroll;

namespace Forecast.Domain.Handlers.Enroll
{
    public interface IClientHandler
    {
        ICommandResult Handle(CreateClientCommand command);
        ICommandResult Handle(UpdateClientCommand command);
    }
}