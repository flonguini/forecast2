using Forecast.Domain.Commands.Enroll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Forecast.Tests.DomainTests.CommandsTests.Enroll
{
    [TestClass]
    public class CreateClientCommandTests
    {
        public static IEnumerable<object[]> GetInvalidCommands()
        {
            yield return new object[] { new CreateClientCommand() };
            yield return new object[] { new CreateClientCommand("","","","","","") };
            yield return new object[] { new CreateClientCommand("as","","","","","") };
            yield return new object[] { new CreateClientCommand("as","","","asd","","") };
            yield return new object[] { new CreateClientCommand("as","","111","asd","","") };
        }

        public static IEnumerable<object[]> GetValidCommands()
        {
            yield return new object[] { new CreateClientCommand("Fernando Longuini", "(11) 3565-5495", "(11) 9 6199-2735", "flonguini@outlook.com", "395.891.568-00", "36.181.396-X") };
        }

        [TestMethod]
        [DynamicData(nameof(GetInvalidCommands), DynamicDataSourceType.Method)]
        public void Invalid_Command_Should_Return_False(CreateClientCommand invalidCommand)
        {
            invalidCommand.Validate();
            Assert.AreEqual(invalidCommand.Valid, false);
        }

        [TestMethod]
        [DynamicData(nameof(GetValidCommands), DynamicDataSourceType.Method)]
        public void Valid_Command_Should_Return_True(CreateClientCommand validCommand)
        {
            validCommand.Validate();
            Assert.AreEqual(validCommand.Valid, true);
        }
    }
}
