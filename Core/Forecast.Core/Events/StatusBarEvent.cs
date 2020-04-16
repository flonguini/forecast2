using Forecast.Domain.Commands.Contracts;
using Prism.Events;

namespace Forecast.Core.Events
{
    public class StatusBarEvent : PubSubEvent<ICommandResult>
    {
    }
}
