using System;

namespace Hotel720.Platform.Infrastructure
{
    public interface IEvent
    {
        Guid Id { get; set; }

        Guid SourceCommandId { get; set; }
    }
}
