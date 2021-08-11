using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Trill.Saga.Messages
{
    [Message("ads")]
    public class AdActionRejected : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        public AdActionRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}