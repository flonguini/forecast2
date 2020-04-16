using Forecast.Domain.Commands;
using Forecast.Domain.Commands.Enroll;
using Forecast.Domain.Entities.Enroll;
using Forecast.Domain.Handlers.Enroll;
using Forecast.Tests.DomainTests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Forecast.Tests.DomainTests.HandlersTests.Enroll
{
    [TestClass]
    public class ClientHandlerTests
    {
        private static Client _validClient = new Client("Fernando", "35655495", "11961992735", "fernando@longuini.com", "39589156800", "36181396x");
        private readonly CreateClientCommand _invalidCommand = new CreateClientCommand(new Client());
        private readonly CreateClientCommand _validCommand = new CreateClientCommand(_validClient);
        private readonly ClientHandler _handler = new ClientHandler(new FakeClientRepository());
        private GenericCommandResult _result;

        [TestMethod]
        public void Invalid_CreateCommand_Should_Return_False()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Valid_CreateCommand_Should_Create_Client()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(true, _result.Success);
        }

        [TestMethod]
        public void Invalid_UpdateCommand_Should_Return_False()
        {
            var invalidUpdateCommand = new UpdateClientCommand(new Client());
            _result = (GenericCommandResult)_handler.Handle(invalidUpdateCommand);
            Assert.AreEqual(false, _result.Success);
        }

        [TestMethod]
        public void Valid_UpdateCommand_Should_Return_False()
        {
            var validUpdateCommand = new UpdateClientCommand(_validClient);
            _result = (GenericCommandResult)_handler.Handle(validUpdateCommand);
            Assert.AreEqual(true, _result.Success);
        }
    }
}
