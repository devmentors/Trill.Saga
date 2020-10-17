using System;
using Convey.CQRS.Commands;
using Convey.MessageBrokers;

namespace Trill.Saga.Commands.External
{
    [Message("ads")]
    public class PublishAd : ICommand
    {
        public Guid AdId { get; }

        public PublishAd(Guid adId)
        {
            AdId = adId;
        }
    }
}