using Forecast.Domain.Entities.Enroll;
using Forecast.Domain.Queries.Enroll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Forecast.Tests.DomainTests.QueriesTests.Enroll
{
    [TestClass]
    public class ClientQueriesTests
    {
        private readonly List<Client> _clients;
        private Client client = new Client("Fernando", "35655495", "11961992735", "fernando@gmail.com", "39589156800", "36181396X");

        public ClientQueriesTests()
        {

            _clients = new List<Client>()
            {
                client,
                new Client("foo", "42325495", "11989665843", "foo@bar.com", "32565895400", "35654789"),
            };

        }

        [TestMethod]
        public void Foo()
        {
            var result = _clients.AsQueryable().Where(ClientQueries.GetClient(client.Id));
            Assert.AreEqual(1, result.Count());
        }
    }
}
