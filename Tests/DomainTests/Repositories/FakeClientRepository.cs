using Forecast.Domain.Entities.Enroll;
using Forecast.Domain.Repositories;
using System;

namespace Forecast.Tests.DomainTests.Repositories
{
    public class FakeClientRepository : IClientRepository
    {
        public void Create(Client client)
        {
        }

        public Client GetClientById(Guid clientId)
        {
            return new Client();
        }

        public void Update(Client client)
        {
        }
    }
}
