using Forecast.Domain.Commands.Contracts;

namespace Forecast.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        #region Public Properties

        public bool Success { get; set ; }
        public string Message { get; set ; }
        public object Data { get; set ; }

        #endregion

        #region Constructors

        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        #endregion
    }
}
