using System.Threading.Tasks;
using Convey.CQRS.Commands;

namespace Trill.Saga.Services
{
    public interface IMessageBroker
    {
        Task SendAsync(params ICommand[] commands);
    }
}