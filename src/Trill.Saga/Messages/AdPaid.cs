using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Trill.Saga.Messages
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