using Forecast.Domain.Entities.Enroll;
using System;
using System.Linq.Expressions;

namespace Forecast.Domain.Queries.Enroll
{
    public static class ClientQueries
    {
        public static Expression<Func<Client, bool>> GetClient(Guid clientId) => x => x.Id == clientId;
    }
}
