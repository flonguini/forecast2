using Forecast.Domain.Commands.Contracts;

namespace Forecast.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
