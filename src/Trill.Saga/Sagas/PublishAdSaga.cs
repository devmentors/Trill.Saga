using System;
using System.Threading.Tasks;
using Chronicle;
using Trill.Saga.Messages;
using Trill.Saga.Services;

namespace Trill.Saga.Sagas
{
    public class PublishAdSaga : Saga<PublishAdSagaData>,
        ISagaStartAction<AdApproved>,
        ISagaAction<AdPaid>,
        ISagaAction<AdPublished>,
        ISagaAction<AdActionRejected>
    {
        private readonly IMessageBroker _messageBroker;

        public PublishAdSaga(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }

        public override SagaId ResolveId(object message, ISagaContext context)
            => message switch
            {
                AdApproved m => m.AdId.ToString(),
                AdPaid m => m.AdId.ToString(),
                AdPublished m => m.AdId.ToString(),
                _ => base.ResolveId(message, context)
                // AdActionRejected m => m.AdId // Extend with AdId
            };

        public Task HandleAsync(AdApproved message, ISagaContext context)
        {
            Data.AdId = message.AdId;
            return Task.CompletedTask;
        }

        public Task CompensateAsync(AdApproved message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(AdPaid message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task CompensateAsync(AdPaid message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(AdPublished message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task CompensateAsync(AdPublished message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(AdActionRejected message, ISagaContext context)
        {
            return Task.CompletedTask;
        }

        public Task CompensateAsync(AdActionRejected message, ISagaContext context)
        {
            return Task.CompletedTask;
        }
    }
    
    public class PublishAdSagaData
    {
        public Guid UserId { get; set; }
        public Guid AdId { get; set; }
    }
}