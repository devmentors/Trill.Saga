using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Trill.Saga.Events.External
{
    [Message("stories")]
    public class StoryActionRejected : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        public StoryActionRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
    }
}