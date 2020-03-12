using Serilog.Core;
using Serilog.Events;

namespace SerilogExample
{
    class UserEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var eventType = propertyFactory.CreateProperty("UserId", "User: " + 1);
            logEvent.AddPropertyIfAbsent(eventType);
        }
    }
}
