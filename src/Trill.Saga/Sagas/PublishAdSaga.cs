using System.Threading.Tasks;
using Chronicle;
using Trill.Saga.Clients;
using Trill.Saga.Commands.External;
using Trill.Saga.Events.External;
using Trill.Saga.Services;

namespace Trill.Saga.Sagas
{
    public class PublishAdSaga : Saga<PublishAdSagaData>,
        ISagaStartAction<AdApproved>,
        ISagaAction<AdPaid>,
        ISagaAction<AdPublished>,
        ISagaAction<AdActionRejected>,
        ISagaAction<StoryActionRejected>
    {
        private readonly IAdApiClient _adApiClient;
        private readonly IMessageBroker _messageBroker;

        public PublishAdSaga(IAdApiClient adApiClient, IMessageBroker messageBroker)
        {
            _adApiClient = adApiClient;
            _messageBroker = messageBroker;
        }
        
        public override SagaId ResolveId(object message, ISagaContext context)
            => message switch
            {
                AdApproved m => (SagaId) m.AdId.ToString(),
                AdPaid m => (SagaId) m.AdId.ToString(),
                AdPublished m => (SagaId) m.AdId.ToString(),
                _ => base.ResolveId(message, context)
            };

        public async Task HandleAsync(AdApproved message, ISagaContext context)
        {
            Data.AdId = message.AdId;
            await _messageBroker.SendAsync(new PayAd(message.AdId));
            // await _adApiClient.PayAsync(message.AdId);
        }

        public Task CompensateAsync(AdApproved message, ISagaContext context)
        {
            return RejectAsync();
        }

        public async Task HandleAsync(AdPaid message, ISagaContext context)
        {
            await _messageBroker.SendAsync(new PublishAd(message.AdId));
            // await _adApiClient.PublishAsync(message.AdId);
        }

        public Task CompensateAsync(AdPaid message, ISagaContext context)
        {
            return RejectAsync();
        }

        public Task HandleAsync(AdPublished message, ISagaContext context)
        {
            return CompleteAsync();
        }

        public Task CompensateAsync(AdPublished message, ISagaContext context)
        {
            return RejectAsync();
        }

        public Task HandleAsync(AdActionRejected message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task CompensateAsync(AdActionRejected message, ISagaContext context)
        {
            return RejectAsync();
        }

        public Task HandleAsync(StoryActionRejected message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task CompensateAsync(StoryActionRejected message, ISagaContext context)
        {
            return RejectAsync();
        }
    }
}