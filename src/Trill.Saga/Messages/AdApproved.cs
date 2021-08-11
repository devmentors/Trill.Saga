using System;
using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Trill.Saga.Messages
{
    [Message("ads")]
    public class AdApproved : IEvent
    {
        public Guid AdId { get; }

        public AdApproved(Guid adId)
        {
            AdId = adId;
        }
    }
}