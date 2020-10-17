using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Events;
using Convey.HTTP;
using Convey.Types;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Trill.Saga.Decorators
{
    [Decorator]
    internal sealed class LoggingEventHandlerDecorator<TEvent> : IEventHandler<TEvent>
        where TEvent : class, IEvent
    {
        private readonly IEventHandler<TEvent> _handler;
        private readonly ICorrelationIdFactory _correlationIdFactory;
        private readonly ILogger<IEventHandler<TEvent>> _logger;

        public LoggingEventHandlerDecorator(IEventHandler<TEvent> handler, ICorrelationIdFactory correlationIdFactory,
            ILogger<IEventHandler<TEvent>> logger)
        {
            _handler = handler;
            _correlationIdFactory = correlationIdFactory;
            _logger = logger;
        }

        public async Task HandleAsync(TEvent @event)
        {
            var correlationId = _correlationIdFactory.Create();
            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                var name = @event.GetType().Name.Underscore();
                _logger.LogInformation($"Handling an event: '{name}'...");
                await _handler.HandleAsync(@event);
            }
        }
    }
}