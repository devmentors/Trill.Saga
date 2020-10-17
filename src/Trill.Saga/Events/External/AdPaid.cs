using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Trill.Saga.Events.External
{
    [Message("ads")]
    public class AdPaid : IEvent
    {
        public Guid AdId { get; }

        public AdPaid(Guid adId)
        {
            AdId = adId;
        }
    }
}