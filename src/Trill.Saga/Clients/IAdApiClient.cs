using System;
using System.Threading.Tasks;

namespace Trill.Saga.Clients
{
    public interface IAdApiClient
    {
        Task<bool> PayAsync(Guid adId);
        Task<bool> PublishAsync(Guid adId);
    }
}