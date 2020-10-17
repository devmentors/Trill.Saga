using System.Threading.Tasks;
using Chronicle;
using Convey.CQRS.Events;

namespace Trill.Saga.Events.External.Handlers
{
    public class AdsEventHandler :
        IEventHandler<AdApproved>,
        IEventHandler<AdPaid>,
        IEventHandler<AdPublished>,
        IEventHandler<AdActionRejected>,
        IEventHandler<StoryActionRejected>
    {
        private readonly ISagaCoordinator _coordinator;

        public AdsEventHandler(ISagaCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public Task HandleAsync(AdApproved @event) => HandleSagaAsync(@event);
        public Task HandleAsync(AdPaid @event) => HandleSagaAsync(@event);
        public Task HandleAsync(AdPublished @event) => HandleSagaAsync(@event);
        public Task HandleAsync(AdActionRejected @event) => HandleSagaAsync(@event);
        public Task HandleAsync(StoryActionRejected @event) => HandleSagaAsync(@event);

        private Task HandleSagaAsync<T>(T @event) where T : class, IEvent
            => _coordinator.ProcessAsync(@event, SagaContext.Empty);
    }
}