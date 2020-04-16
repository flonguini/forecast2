using Forecast.Domain.Entities.Enroll;
using System;

namespace Forecast.Domain.Repositories
{
    public interface IClientRepository
    {
        void Create(Client client);
        Client GetClientById(Guid clientId);
        void Update(Client client);
    }
}
