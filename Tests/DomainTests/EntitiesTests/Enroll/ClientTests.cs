using Forecast.Domain.Entities.Enroll;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Forecast.Tests.DomainTests.EntitiesTests.Enroll
{
    [TestClass]
    public class ClientTests
    {
        private readonly Client _client;

        public ClientTests()
        {
            _client = new Client();
        }
        
        [TestMethod]
        public void New_Client_Should_Have_New_Id()
        {
            Assert.IsNotNull(_client.Id);
        }

        [TestMethod]
        public void Should_Change_Client_FullName()
        {
            _client.ChangeFullName("Fernando");
            Assert.AreEqual(_client.FullName, "Fernando");
        }

        [TestMethod]
        public void Should_Change_Client_Phone()
        {
            _client.ChangePhone("1135655495");
            Assert.AreEqual(_client.Phone, "1135655495");
        }

        [TestMethod]
        public void Should_Change_Client_CellPhone()
        {
            _client.ChangeCellPhone("11961992735");
            Assert.AreEqual(_client.CellPhone, "11961992735");
        }

        [TestMethod]
        public void Should_Change_Client_Email()
        {
            _client.ChangeEmail("fernando@longuini.com");
            Assert.AreEqual(_client.Email, "fernando@longuini.com");
        }

        [TestMethod]
        public void Should_Change_Client_Cpf()
        {
            _client.ChangeCpf("39589156800");
            Assert.AreEqual(_client.Cpf, "39589156800");
        }

        [TestMethod]
        public void Should_Change_Client_Rg()
        {
            _client.ChangeRg("36181396x");
            Assert.AreEqual(_client.Rg, "36181396x");
        }
    }
}
