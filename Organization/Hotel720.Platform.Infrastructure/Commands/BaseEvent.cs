using System;

namespace Hotel720.Platform.Infrastructure
{
    public abstract class BaseEvent : IEvent
    {
        public Guid Id { get; set; }
        
        public Guid SourceCommandId { get; set; }
    }
}
