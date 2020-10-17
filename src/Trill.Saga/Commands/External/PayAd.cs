using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace Trill.Saga.Commands.External
{
    [Message("ads")]
    public class PayAd : ICommand
    {
        public Guid AdId { get; }

        public PayAd(Guid adId)
        {
            AdId = adId;
        }
    }
}