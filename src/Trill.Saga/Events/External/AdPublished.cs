using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Trill.Saga.Events.External
{
    [Message("ads")]
    public class AdPublished : IEvent
    {
        public Guid AdId { get; }

        public AdPublished(Guid adId)
        {
            AdId = adId;
        }
    }
}