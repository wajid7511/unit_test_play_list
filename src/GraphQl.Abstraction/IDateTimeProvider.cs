using System;

namespace GraphQl.Abstraction;

public interface IDateTimeProvider
{
    public DateTime Now { get; }

    public DateTime UtcNow { get; }
}
